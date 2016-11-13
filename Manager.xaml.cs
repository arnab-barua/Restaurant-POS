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
//using System.Windows.Forms;
using System.ComponentModel;

namespace RestaurentMngment
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    /// 
    public partial class Manager : Window
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public Manager()
        {
            InitializeComponent();
            loadForm();
        }

        private void loadForm()
        {
            SqlConnection sqlConFill = new SqlConnection(conn);
            SqlCommand cmdFill = new SqlCommand();
            cmdFill.CommandText = "SELECT discount,service_charge FROM prime WHERE Id=" + '1';
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            SqlDataReader rd = cmdFill.ExecuteReader();
            String cat = "";
            if (rd.HasRows)
            {
                rd.Read();
                CurrentDiscount.Text = rd[0].ToString();
                CurrentSerCharge.Text = rd[1].ToString();
                cat = cat + rd[0].ToString();
                sqlConFill.Close();
            }
        }

        private void Catagory_Click(object sender, RoutedEventArgs e)
        {
            Catagory win2 = new Catagory();
            win2.Show();
            this.Close();
        }

        private void items_Click(object sender, RoutedEventArgs e)
        {
            Item win2 = new Item();
            win2.Show();
            this.Close();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainMenu win2 = new MainMenu();
            win2.Show();
            this.Close();
        }

        private void service_button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(NewSerCharge.Text))
            {
                SqlConnection sqlConFill = new SqlConnection(conn);
                SqlCommand cmdFill = new SqlCommand();
                cmdFill.CommandText = "UPDATE prime SET service_charge=@NewSerCharge WHERE Id=" + '1';
                cmdFill.Parameters.AddWithValue("@NewSerCharge", NewSerCharge.Text);
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                cmdFill.ExecuteNonQuery();
                sqlConFill.Close();
                MessageBox.Show("Service Charge Rate Changed");
                CurrentSerCharge.Text = NewSerCharge.Text;
                NewSerCharge.Clear();
            }
            else
            {
                MessageBox.Show("Invalid Service Charge Rate", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void discount_button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(NewDiscount.Text))
            {
                SqlConnection sqlConFill = new SqlConnection(conn);
                SqlCommand cmdFill = new SqlCommand();
                cmdFill.CommandText = "UPDATE prime SET discount=@NewDiscount WHERE Id=" + '1';
                cmdFill.Parameters.AddWithValue("@NewDiscount", NewDiscount.Text);
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                cmdFill.ExecuteNonQuery();
                sqlConFill.Close();
                MessageBox.Show("Discount Rate Changed");
                CurrentDiscount.Text = NewDiscount.Text;
                NewDiscount.Clear();
            }
            else
            {
                MessageBox.Show("Invalid Discount Rate", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void password_button_Click(object sender, RoutedEventArgs e)
        {
            String current = CurrentPass.Password;
            String new_pass = NewPass.Password;
            if (!String.IsNullOrEmpty(current) && !String.IsNullOrEmpty(new_pass))
            {
                if (new_pass.Length < 5)
                {
                    MessageBox.Show("Minimum Password length is 5");
                }
                else
                {
                    SqlConnection sqlConFill = new SqlConnection(conn);
                    SqlCommand cmdFill = new SqlCommand();
                    cmdFill.CommandText = "SELECT adm_password FROM prime WHERE Id=" + '1';
                    cmdFill.Connection = sqlConFill;
                    sqlConFill.Open();
                    SqlDataReader rd = cmdFill.ExecuteReader();
                    String cat = "";
                    if (rd.HasRows)
                    {
                        rd.Read();
                        cat = rd[0].ToString();
                        sqlConFill.Close();
                    }
                    rd.Close();
                    sqlConFill.Close();
                    if (cat == current)
                    {
                        sqlConFill = new SqlConnection(conn);
                        cmdFill = new SqlCommand();
                        cmdFill.CommandText = "UPDATE prime SET adm_password=@new_pass WHERE Id=" + '1';
                        cmdFill.Parameters.AddWithValue("@new_pass", new_pass);
                        cmdFill.Connection = sqlConFill;
                        sqlConFill.Open();
                        cmdFill.ExecuteNonQuery();
                        sqlConFill.Close();

                        MessageBox.Show("Password Changed", " ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        CurrentPass.Clear();
                        NewPass.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Password not Matched", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Current or New Password Field is Empty", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
