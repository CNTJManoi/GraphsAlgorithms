using System.Windows;

namespace GraphsAlgorithms.View;

/// <summary>
///     Логика взаимодействия для PathDialog.xaml
/// </summary>
public partial class PathDialog : Window
{
    public PathDialog()
    {
        InitializeComponent();
    }

    public string Price => pathBox.Text;

    private void Accept_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}