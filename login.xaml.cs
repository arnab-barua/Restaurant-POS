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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RestaurentMngment
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public login()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            String pass = password.Password;
            SqlConnection sqlConFill = new SqlConnection(conn);
            SqlCommand cmdFill = new SqlCommand();
            cmdFill.CommandText = "SELECT adm_password FROM prime WHERE Id = " + '1';
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            SqlDataReader rd = cmdFill.ExecuteReader();
            String cat = "";
            if (rd.HasRows)
            {
                rd.Read();
                cat = cat + rd[0].ToString();
                rd.Close();
            }
            sqlConFill.Close();
            if (cat == pass)
            {
                MainMenu win2 = new MainMenu();
                win2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                password.Clear();
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
