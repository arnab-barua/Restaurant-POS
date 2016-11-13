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
using System.Windows.Markup;

namespace RestaurentMngment
{
    /// <summary>
    /// Interaction logic for Billing.xaml
    /// </summary>
    public partial class Billing : Window
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        Double dis;
        Double ser;
        Double tax;
        Double ttl;
        Double taxcrg;
        Double newttl;
        public Billing()
        {
            InitializeComponent();
            loadForm();
            loadComponent();
            loadExtra();
        }

        private void loadForm()
        {
            SqlConnection sqlConFill = new SqlConnection(conn);
            SqlCommand cmdFill = new SqlCommand();
            cmdFill.CommandText = "SELECT Food_Id,CatagoryName,FoodName,Price FROM Foods WHERE Food_Id IS NOT NULL order by Catagory_Id";
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmdFill);
            DataTable dt = new DataTable("Foods");
            sda.Fill(dt);
            lvUsers2.ItemsSource = dt.DefaultView;
            sqlConFill.Close();


            cmdFill.CommandText = "SELECT * FROM orders WHERE serial IS NOT NULL";
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            sda = new SqlDataAdapter(cmdFill);
            dt = new DataTable("orders");
            sda.Fill(dt);
            lvUsers3.ItemsSource = dt.DefaultView;
            sqlConFill.Close();
        }
        private void loadComponent()
        {
            SqlConnection sqlConFill = new SqlConnection(conn);
            SqlCommand cmdFill = new SqlCommand();
            cmdFill.CommandText = "SELECT discount,service_charge,tax FROM prime WHERE Id IS NOT NULL";
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            SqlDataReader rd = cmdFill.ExecuteReader();
            String cat = "";
            if (rd.HasRows)
            {
                rd.Read();
                dis = Convert.ToDouble(rd[0]);
                ser = Convert.ToDouble(rd[1]);
                tax = Convert.ToDouble(rd[2]);
                rd.Close();
            }
            sqlConFill.Close();
        }

        private void change2(object sender, RoutedEventArgs e)
        {
            String txt = Convert.ToString(((DataRowView)lvUsers2.SelectedItem)["Food_Id"]);
            if (txt != null)
            {
                foodIdTxt.Text = Convert.ToString(((DataRowView)lvUsers2.SelectedItem)["Food_Id"]);
                foodNameTxt.Text = Convert.ToString(((DataRowView)lvUsers2.SelectedItem)["FoodName"]);
                priceTxt.Text = Convert.ToString(((DataRowView)lvUsers2.SelectedItem)["Price"]);
            }
            update.IsEnabled = false;
            delete.IsEnabled = false;
            create.IsEnabled = true;
        }

        private void change3(object sender, RoutedEventArgs e)
        {
            String txt = Convert.ToString(((DataRowView)lvUsers3.SelectedItem)["foodId"]);
            if (txt != null)
            {
                foodIdTxt.Text = Convert.ToString(((DataRowView)lvUsers3.SelectedItem)["foodId"]);
                serialTxt.Text = Convert.ToString(((DataRowView)lvUsers3.SelectedItem)["serial"]);
                foodNameTxt.Text = Convert.ToString(((DataRowView)lvUsers3.SelectedItem)["foodName"]);
                priceTxt.Text = Convert.ToString(((DataRowView)lvUsers3.SelectedItem)["price"]);
                quantityTxt.Text = Convert.ToString(((DataRowView)lvUsers3.SelectedItem)["quantity"]);
            }
            create.IsEnabled = false;
            update.IsEnabled = true;
            delete.IsEnabled = true;
        }

        private void loadExtra()
        {

            SqlConnection sqlConFill = new SqlConnection(conn);
            SqlCommand cmdFill = new SqlCommand();
            cmdFill.CommandText = "SELECT SUM(total) FROM orders WHERE serial IS NOT NULL";
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            SqlDataReader rd = cmdFill.ExecuteReader();
            String cat = "";
            if (rd.HasRows)
            {
                rd.Read();
                var outputParam = rd[0];
                if (!(outputParam is DBNull))
                {
                    ttl = Convert.ToDouble(rd[0]);
                }
                rd.Close();
            }
            sqlConFill.Close();
            Double sercrg = ttl * ser / 100;
            Double discrg = ttl * dis / 100;
            Double taxcrg = ttl * tax / 100;
            Double netttl = ttl + sercrg - discrg;
            fTotal.Text = ttl.ToString();
            ser_charge.Text = sercrg.ToString();
            discount.Text = discrg.ToString();
            net_total.Text = netttl.ToString();

            newttl = netttl + taxcrg;
            tax_charge.Text = taxcrg.ToString();
            total.Text = newttl.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goingBack();
            MainMenu win2 = new MainMenu();
            win2.Show();
            this.Close();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(quantityTxt.Text) && !String.IsNullOrEmpty(foodIdTxt.Text))
            {
                int sr = 0;
                SqlConnection sqlConFill = new SqlConnection(conn);
                SqlCommand cmdFill = new SqlCommand();
                cmdFill.CommandText = "SELECT MAX(serial) FROM orders";
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                SqlDataReader rd1 = cmdFill.ExecuteReader();
                if (rd1.HasRows)
                {
                    rd1.Read();
                    var outputParam = rd1[0];
                    if (!(outputParam is DBNull))
                    {
                        sr = Convert.ToInt32(rd1[0]);
                    }
                    else
                    {
                        sr = 0;
                    }
                    rd1.Close();
                }
                sqlConFill.Close();
                sr = sr + 1;

                SqlConnection sqlConFillck = new SqlConnection(conn);
                SqlCommand cmdFillck = new SqlCommand();
                cmdFillck.CommandText = "SELECT serial FROM orders WHERE foodId=@Id ";
                cmdFillck.Parameters.AddWithValue("@Id", foodIdTxt.Text);
                cmdFillck.Connection = sqlConFillck;
                sqlConFillck.Open();
                SqlDataReader rd = cmdFillck.ExecuteReader();
                String cat = "";
                if (rd.HasRows)
                {
                    rd.Read();
                    cat = cat + rd[0].ToString();
                    rd.Close();
                    sqlConFillck.Close();
                    MessageBox.Show("Item Already Exist at Serial " + cat);
                }

                else
                {
                    sqlConFillck.Close();
                    int p = Convert.ToInt32(priceTxt.Text);
                    int q = Convert.ToInt32(quantityTxt.Text);
                    int tt = p * q;
                    cmdFill.CommandText = "INSERT INTO orders(serial,foodId,foodName,price,quantity,total)VALUES (@serial,@foodId,@foodName,@price,@quantity,@total)";
                    cmdFill.Parameters.AddWithValue("@serial", sr.ToString());
                    cmdFill.Parameters.AddWithValue("@foodId", foodIdTxt.Text);
                    cmdFill.Parameters.AddWithValue("@foodName", foodNameTxt.Text);
                    cmdFill.Parameters.AddWithValue("@price", priceTxt.Text);
                    cmdFill.Parameters.AddWithValue("@quantity", quantityTxt.Text);
                    cmdFill.Parameters.AddWithValue("@total", tt);
                    cmdFill.Connection = sqlConFill;
                    sqlConFill.Open();
                    cmdFill.ExecuteNonQuery();
                    sqlConFill.Close();
                    Billing win2 = new Billing();
                    win2.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Quantity field cann't be empty", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(quantityTxt.Text) && !String.IsNullOrEmpty(foodIdTxt.Text))
            {
                SqlConnection sqlConFill = new SqlConnection(conn);
                SqlCommand cmdFill = new SqlCommand();
                int p = Convert.ToInt32(priceTxt.Text);
                int q = Convert.ToInt32(quantityTxt.Text);
                int tt = p * q;
                cmdFill.CommandText = "UPDATE orders SET foodid=@foodId,foodName=@foodName,price=@price,quantity=@quantity,total=@total WHERE serial=@serial";
                cmdFill.Parameters.AddWithValue("@foodId", foodIdTxt.Text);
                cmdFill.Parameters.AddWithValue("@foodName", foodNameTxt.Text);
                cmdFill.Parameters.AddWithValue("@price", priceTxt.Text);
                cmdFill.Parameters.AddWithValue("@quantity", quantityTxt.Text);
                cmdFill.Parameters.AddWithValue("@total", tt);
                cmdFill.Parameters.AddWithValue("@serial", serialTxt.Text);
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                cmdFill.ExecuteNonQuery();
                Billing win2 = new Billing();
                win2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Food Id or Quantity field cann't be empty");
            }
        }

        private void delete_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConFill = new SqlConnection(conn);
            SqlCommand cmdFill = new SqlCommand();
            cmdFill.CommandText = "DELETE FROM orders WHERE serial=@serial";
            cmdFill.Parameters.AddWithValue("@serial", serialTxt.Text.ToString());
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            cmdFill.ExecuteNonQuery();
            sqlConFill.Close();

            cmdFill.CommandText = "UPDATE orders SET serial=serial-1 WHERE serial>@upSerial2";
            cmdFill.Parameters.AddWithValue("@upSerial2", serialTxt.Text.ToString());
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            cmdFill.ExecuteNonQuery();
            sqlConFill.Close();

            Billing win2 = new Billing();
            win2.Show();
            this.Close();
        }

        private void Print_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
            if (pd.ShowDialog() != true) return;

            // create a document
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight);

            // create a page
            FixedPage page1 = new FixedPage();
            page1.Width = document.DocumentPaginator.PageSize.Width;
            page1.Height = document.DocumentPaginator.PageSize.Height;

            //adding header
            TextBlock page2Text = new TextBlock();
            page2Text.Text = "Billing";
            page2Text.FontSize = 20;
            page2Text.Margin = new Thickness(300, 0, 0, 0);
            page1.Children.Add(page2Text);

            //adding date
            TextBlock date11 = new TextBlock();
            date11.FontFamily = new FontFamily("Consolas");
            date11.Text = "Date \t: " + DateTime.Now.ToShortDateString() + "\nTime \t: " + DateTime.Now.ToShortTimeString();
            date11.FontSize = 15;
            date11.Margin = new Thickness(250, 22, 0, 0);
            page1.Children.Add(date11);

            //adding grid
            sp.Children.Remove(lvUsers3);
            lvUsers3.Margin = new System.Windows.Thickness(0, 65, 0, 0);
            page1.Children.Add(lvUsers3);


            //add extra footer data
            int m = Convert.ToInt32(lvUsers3.ActualHeight);
            m = m + 80;
            String one = "Total Food Price \t: " + fTotal.Text + " Tk\nService Charge (" + ser.ToString() + "%)\t: " + ser_charge.Text + " Tk\nDiscount (" + dis.ToString() + "%)\t\t: " + discount.Text + " Tk\nTotal Without VAT \t: " + net_total.Text + " Tk\nVAT (" + tax.ToString() + "%)\t\t: " + tax_charge.Text + " Tk\nTotal With VAT \t: " + total.Text + " Tk";
            TextBlock footer = new TextBlock();
            footer.Text = one;
            footer.FontFamily = new FontFamily("Consolas");
            footer.FontSize = 12;
            footer.Margin = new Thickness(200, m, 0, 0);
            page1.Children.Add(footer);

            // add the page to the document
            PageContent page1Content = new PageContent();
            ((IAddChild)page1Content).AddChild(page1);
            document.Pages.Add(page1Content);
            pd.PrintDocument(document.DocumentPaginator, Title);

            page1.Children.Remove(lvUsers3);
            lvUsers3.Margin = new Thickness(0, 0, 0, 0);
            sp.Children.Add(lvUsers3);

            finalTask();
            goingBack();
            Billing win2 = new Billing();
            win2.Show();
            this.Close();
        }

        private void finalTask()
        {
            SqlConnection sqlConFill = new SqlConnection(conn);
            SqlCommand cmdFill = new SqlCommand();
            cmdFill.CommandText = "INSERT INTO ladger(date,time,ttl,taxcrg,newttl)VALUES (@date,@time,@ttl,@taxcrg,@newttl)";
            cmdFill.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
            cmdFill.Parameters.AddWithValue("@time", DateTime.Now.ToShortTimeString());
            cmdFill.Parameters.AddWithValue("@ttl", ttl.ToString());
            cmdFill.Parameters.AddWithValue("@taxcrg", tax_charge.Text);
            cmdFill.Parameters.AddWithValue("@newttl", newttl.ToString());
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            cmdFill.ExecuteNonQuery();
            sqlConFill.Close();
        }

        private void goingBack()
        {
            SqlConnection sqlConFill = new SqlConnection(conn);
            SqlCommand cmdFill = new SqlCommand();
            cmdFill.CommandText = "DELETE FROM orders";
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            cmdFill.ExecuteNonQuery();
            sqlConFill.Close();

        }

    }
}
