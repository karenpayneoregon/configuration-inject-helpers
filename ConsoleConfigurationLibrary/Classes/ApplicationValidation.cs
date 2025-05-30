﻿using System.Linq.Expressions;
using ConsoleConfigurationLibrary.Models;
using Microsoft.Extensions.Configuration;
using static ConsoleConfigurationLibrary.Classes.Configuration;

namespace ConsoleConfigurationLibrary.Classes;

/// <summary>
/// Provides functionality to validate application configuration during startup.
/// </summary>
/// <remarks>
/// This class ensures that essential configuration sections, such as connection strings, 
/// are present and properly configured when the application starts. It leverages helper 
/// methods to check the existence of configuration sections and retrieve required settings.
/// </remarks>
public class ApplicationValidation
{
    /// <summary>
    /// Validates the application's configuration during startup.
    /// </summary>
    /// <remarks>
    /// This method ensures that essential configuration sections, such as connection strings, 
    /// are present and properly configured. It retrieves the "ConnectionStrings" section and 
    /// validates the main connection string to ensure the application can operate correctly.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the required "ConnectionStrings" section or the main connection string is missing or invalid.
    /// </exception>
    public static void ValidateOnStart()
    {
        if (ConnectionHelpers.MainConnectionStringsSectionExist())
        {
            var section = JsonRoot().GetRequiredSection(nameof(ConnectionStrings));
            var value = section?.GetValue<string>(nameof(ConnectionStrings.MainConnection));
            if (value != null)
            {
                Connection.Validator(value);
            }
            else
            {
                throw new ApplicationException($"Missing property '{nameof(ConnectionStrings.MainConnection)}'");
            }
        }
        else
        {
            throw new InvalidOperationException($"The required configuration section '{nameof(ConnectionStrings)}' is missing.");
        }
    }

    /// <summary>
    /// Validates a specific configuration section and a property within it during application startup.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the configuration section to validate. Must be a reference type.
    /// </typeparam>
    /// <param name="sectionName">
    /// The name of the configuration section to validate.
    /// </param>
    /// <param name="propertySelector">
    /// A function that selects a specific property from the configuration section for validation.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the required configuration section is missing or if the selected property is null.
    /// </exception>
    /// <remarks>
    /// This method ensures that the specified configuration section exists and retrieves its value.
    /// It uses the provided <paramref name="propertySelector"/> to validate a specific property within the section.
    /// If the configuration section or the selected property is not properly configured, an exception is thrown.
    /// </remarks>
    public static void ValidateOnStart<T>(string sectionName, Expression<Func<T, string>> propertySelector) where T : class
    {
        if (ConnectionHelpers.SectionExists(sectionName))
        {
            var section = JsonRoot().GetRequiredSection(sectionName).Get<T>();

            if (section is null) return;
            var compiledSelector = propertySelector.Compile();
            var propertyName = GetPropertyName(propertySelector);
            var value = compiledSelector(section);
            if (value is not null)
            {
                Connection.Validator(value);
            }
            else
            {
                throw new InvalidOperationException($"The required property '{propertyName}' is missing");
            }
        }
        else
        {
            throw new InvalidOperationException($"The required configuration section '{sectionName}' is missing.");
        }
    }

    /// <summary>
    /// Validates the specified configuration section and its properties during application startup.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the configuration section to validate. This type must be a reference type.
    /// </typeparam>
    /// <param name="sectionName">
    /// The name of the configuration section to validate.
    /// </param>
    /// <param name="propertySelectors">
    /// An array of expressions representing the properties of the configuration section to validate.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the specified configuration section is missing, or when any of the required properties
    /// in the section are missing or invalid.
    /// </exception>
    /// <remarks>
    /// This method ensures that the specified configuration section exists and validates the values of the
    /// provided properties. If a property is missing or invalid, an exception is thrown to prevent the 
    /// application from starting with incomplete or incorrect configuration.
    /// </remarks>
    public static void ValidateOnStart<T>(string sectionName, params Expression<Func<T, string>>[] propertySelectors) where T : class
    {
        if (!ConnectionHelpers.SectionExists(sectionName))
        {
            throw new InvalidOperationException($"The required configuration section '{sectionName}' is missing.");
        }

        var section = JsonRoot().GetRequiredSection(sectionName).Get<T>();

        if (section is null) return;

        foreach (var selector in propertySelectors)
        {
            var compiledSelector = selector.Compile();
            var propertyName = GetPropertyName(selector);
            var value = compiledSelector(section);

            if (value is not null)
            {
                Connection.Validator(value);
            }
            else
            {
                throw new InvalidOperationException($"The required property '{propertyName}' is missing.");
            }
        }
    }

    /// <summary>
    /// Retrieves the name of the property specified in the given expression.
    /// </summary>
    /// <typeparam name="T">The type of the object containing the property.</typeparam>
    /// <param name="propertySelector">
    /// An expression that specifies the property for which the name is to be retrieved.
    /// </param>
    /// <returns>The name of the property specified in the expression.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the provided <paramref name="propertySelector"/> expression is invalid or does not represent a property.
    /// </exception>
    private static string GetPropertyName<T>(Expression<Func<T, string>> propertySelector) =>
        propertySelector.Body switch
        {
            MemberExpression memberExpression => memberExpression.Member.Name,
            UnaryExpression { Operand: MemberExpression operandExpression } => operandExpression.Member.Name,
            _ => throw new ArgumentException("Invalid property selector expression", nameof(propertySelector))
        };
}