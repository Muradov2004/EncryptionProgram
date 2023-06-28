using System.Windows;
using Wpf.Ui.Controls;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace EncryptionProgram;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : UiWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void DialogButton_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            FileName = "Encryption file",
            DefaultExt = ".txt",
            Filter = "Text documents (.txt)|*.txt"
        };

        bool? result = dialog.ShowDialog();

        if (result == true)
        {
            FilePathTxtBox.Text = dialog.FileName;
        }
    }

    private void NumericPasswordBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!IsNumericInput(e.Text))
            e.Handled = true;

    }

    private bool IsNumericInput(string input)
    {
        string pattern = "[^0-9]+";

        return !Regex.IsMatch(input, pattern);
    }


}
