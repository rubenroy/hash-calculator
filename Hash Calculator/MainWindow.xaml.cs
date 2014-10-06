using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.IO;
namespace Hash_Calculator

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // UI
        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlgChooseFile = new Microsoft.Win32.OpenFileDialog();
            // Show open file dialog box
            Nullable<bool> result = dlgChooseFile.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = dlgChooseFile.FileName;
                txtChooseFile.Text = filename;
            }
        }


        private async void CalculateHash_Click(object sender, RoutedEventArgs e)
        {
            var pthFile = txtChooseFile.Text;
            if(!(File.Exists(pthFile)))
            {
                return;
            }

            var strWorking = "Calculating...";

            if (chkMD5.IsChecked == true)
            {
                txtMD5.Text = strWorking;
                var tskMD5 = Task.Run(() => clcMD5(pthFile));
                tskMD5.ContinueWith(cmpMD5 => txtMD5.Text = cmpMD5.Result.ToString(), TaskScheduler.FromCurrentSynchronizationContext());
            }

            if (chkSHA1.IsChecked == true)
            {
                txtSHA1.Text = strWorking;
                var tskSHA1 = Task.Run(() => clcSHA1(pthFile));
                tskSHA1.ContinueWith(cmpSHA1 => txtSHA1.Text = cmpSHA1.Result.ToString(), TaskScheduler.FromCurrentSynchronizationContext());
            }
           
        }

        private string clcMD5(string filepath)
        {
            var md5 = MD5.Create();
            var stream = File.OpenRead(filepath);
            var hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }

        private string clcSHA1(string filepath)
        {
            var sha1 = SHA1.Create();
            var stream = File.OpenRead(filepath);
            var hash = sha1.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", string.Empty);

        }

    }
}
