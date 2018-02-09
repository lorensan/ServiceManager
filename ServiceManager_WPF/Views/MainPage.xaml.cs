using ServiceManager_WPF.Controller;
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

namespace ServiceManager_WPF.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text.ToString()))
            {
                FilterByString(textBox1.Text);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            serviceGrid.ItemsSource= ServiceControllerClass.ListServices();
        }

        private void rbStopped_Click(object sender, RoutedEventArgs e)
        {
            logBox.Items.Add("FILTER: Stopped services selected.");
            serviceGrid.ItemsSource = ServiceControllerClass.ListStoppedServices();
        }

        private void rbRunning_Click(object sender, RoutedEventArgs e)
        {
            logBox.Items.Add("FILTER: Running services selected.");
            serviceGrid.ItemsSource = ServiceControllerClass.ListRunningServices();
        }
    }
}
