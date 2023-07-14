using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace TimeTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer test;
        private Stopwatch stopwatch;

        public MainWindow()
        {
            InitializeComponent();

            stopwatch = new Stopwatch();

            test = new DispatcherTimer();
            test.Tick += new EventHandler(Update_time); // Tick'den sonra += artma(dakika gibi)
            test.Start();

            Click_Continue.Visibility = Visibility.Hidden;


        }

        private void Update_time(object sender, EventArgs e)
        {
            DisplayTime.Text = DateTime.Now.ToString();
        }

        private void Click_Stop_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Stopped Time");
            stopwatch.Stop();
            test.Stop();


            //Aşağıdaki amaç bir butonu bastıktan sonra görülmez olan button çıksın ortaya
            Click_Continue.Visibility = Visibility.Hidden;
            if (Click_Continue.Visibility == Visibility.Hidden)
            {
                Click_Continue.Visibility = Visibility.Visible;
            }
        }

        private void Click_Continue_Click(object sender, RoutedEventArgs e)
        {
            //stopwatch.Reset();   //not working
            test.Start();
            DisplayTime.Text = DateTime.Now.ToString();
        }
    }
}
