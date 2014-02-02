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
            // Start progress bar
            prgCalculateHash.IsIndeterminate = true;

           Task[] arrTasks = new Task;

            var tskMD5 = Task.Run(() => clcMD5("Moep"));
            tskMD5.ContinueWith(cmpMD5 => txtMD5.Text = cmpMD5.Result.ToString(), TaskScheduler.FromCurrentSynchronizationContext());
            arrTasks.
            
            await Task.Delay(2000);

            // Wait for all tasks to complete
            Task.WaitAll();

            // Stop progress bar
            prgCalculateHash.IsIndeterminate = false;
        }

        private string clcMD5(string Moep)
        {
            System.Threading.Thread.Sleep(5000);
            return "1";
        }


    }
}
