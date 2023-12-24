namespace ConsoleConfigurationApp.Models;
internal class OrderDetails
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal RowTotal { get; set; }
    public string ProductName { get; set; }

}
