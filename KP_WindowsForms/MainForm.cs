namespace KP_WindowsForms;

public partial class MainForm : Form
{
 
    public MainForm()
    {
        InitializeComponent();
        var instanceMainConnection = DataConnections.Instance.Main;
    }

}
