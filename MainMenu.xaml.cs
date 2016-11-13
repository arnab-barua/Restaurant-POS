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
using System.Windows.Shapes;

namespace RestaurentMngment
{

    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void billing_Click(object sender, RoutedEventArgs e)
        {
            Billing win2 = new Billing();
            win2.Show();
            this.Close();
        }

        private void manage_Click(object sender, RoutedEventArgs e)
        {
            Manager win2 = new Manager();
            win2.Show();
            this.Close();
        }

        private void report_Click(object sender, RoutedEventArgs e)
        {
            Report win2 = new Report();
            win2.Show();
            this.Close();
        }

        private void texreport_Click(object sender, RoutedEventArgs e)
        {
            TaxReport win2 = new TaxReport();
            win2.Show();
            this.Close();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            login win2 = new login();
            win2.Show();
            this.Close();
        }
    }
}
