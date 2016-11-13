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
    /// Interaction logic for TexReport.xaml
    /// </summary>
    public partial class TaxReport : Window
    {
        public TaxReport()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu win2 = new MainMenu();
            win2.Show();
            this.Close();
        }
    }
}
