using System.Windows;
using Wpf.Ui.Controls;
using Microsoft.Win32;

namespace EncryptionProgram
{
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
            var dialog = new OpenFileDialog();
            dialog.FileName = "Encryption file"; 
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt"; 

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                FilePathTxtBox.Text = dialog.FileName;
            }
        }
    }
}
