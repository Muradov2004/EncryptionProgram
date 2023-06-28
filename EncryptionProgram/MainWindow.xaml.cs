using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using Wpf.Ui.Controls;
using System.IO;
using System.Threading;
using System;
using System.Text;

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
            StartButton.IsEnabled = true;
        }
    }

    private void NumericPasswordBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!IsNumericInput(e.Text)) e.Handled = true;
    }

    private bool IsNumericInput(string input)
    {
        string pattern = "[^0-9]+";
        return !Regex.IsMatch(input, pattern);
    }

    private void FilePathTxtBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (FilePathTxtBox.Text != string.Empty) StartButton.IsEnabled = true;
        else StartButton.IsEnabled = false;
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        if (File.Exists(FilePathTxtBox.Text))
        {
            string text = File.ReadAllText(FilePathTxtBox.Text);
            Encrypter encrypter = new Encrypter()
            {
                EncryptionKey = Convert.ToInt32(PswrdBox.Password)
            };
            Thread thread = new Thread(
                () =>
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        StringBuilder @string = new StringBuilder(text);
                        @string[i] = encrypter.Encrypt(text[i]);
                        text = @string.ToString();
                        File.WriteAllText(FilePathTxtBox.Text, text);
                        EncryptionProgressBar.Value += 1;
                    }
                });


        }
    }
}
