using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using System.ComponentModel;

namespace AsyncWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker worker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            Progress.Minimum = 1;
            Progress.Maximum = 100;

            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.ProgressChanged += Worker_ProgressChanged;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress.Value = e.ProgressPercentage;
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Cancelled");
                Progress.Value = 1;
            }
            else
            {
                MessageBox.Show("Done");
            }
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                System.Threading.Thread.Sleep(100);
                worker.ReportProgress(i);
            }
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                worker.RunWorkerAsync();
            }
            catch
            {
                MessageBox.Show("Cancel current procces to start new one.");
            }        
        }
        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
        }
    }
}