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

namespace RestaurentMngment
{
    /// <summary>
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class Item : Window
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public Item()
        {
            InitializeComponent();
            loadForm();
        }

        private void loadForm()
        {
            SqlConnection sqlConFill = new SqlConnection(conn);
            SqlCommand cmdFill = new SqlCommand();
            cmdFill.CommandText = "SELECT * FROM Foods ORDER BY Food_Id";
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmdFill);
            DataTable dt = new DataTable("Foods");
            sda.Fill(dt);
            lvUsers.ItemsSource = dt.DefaultView;
            sqlConFill.Close();
            FoodIdTxt.Text = null;
            CatagoryIdTxt.Text = null;
            FoodNameTxt.Text = null;
            PriceTxt.Text = null;
            DescriptionTxt.Text = null;
        }

        private void change(object sender, RoutedEventArgs e)
        {
            String txt = Convert.ToString(((DataRowView)lvUsers.SelectedItem)["Food_Id"]);
            if (txt != null)
            {
                FoodIdTxt.Text = Convert.ToString(((DataRowView)lvUsers.SelectedItem)["Food_Id"]);
                CatagoryIdTxt.Text = Convert.ToString(((DataRowView)lvUsers.SelectedItem)["Catagory_Id"]);
                FoodNameTxt.Text = Convert.ToString(((DataRowView)lvUsers.SelectedItem)["FoodName"]);
                PriceTxt.Text = Convert.ToString(((DataRowView)lvUsers.SelectedItem)["Price"]);
                DescriptionTxt.Text = Convert.ToString(((DataRowView)lvUsers.SelectedItem)["Description"]);
            }
        }
        String cat = "";

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CatagoryIdTxt.Text) && !String.IsNullOrEmpty(FoodNameTxt.Text) && !String.IsNullOrEmpty(PriceTxt.Text))
            {
                int sr = 0;
                SqlConnection sqlConFill = new SqlConnection(conn);
                SqlCommand cmdFill = new SqlCommand();
                cmdFill.CommandText = "SELECT MAX(Food_Id) FROM Foods";
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

                cmdFill.CommandText = "SELECT Food_Id FROM Foods WHERE Catagory_Id=@Id AND FoodName=@Name";
                cmdFill.Parameters.AddWithValue("@Id", CatagoryIdTxt.Text);
                cmdFill.Parameters.AddWithValue("@Name", FoodNameTxt.Text);
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                SqlDataReader rd = cmdFill.ExecuteReader();
                String cat = "";
                if (rd.HasRows)
                {
                    rd.Read();
                    cat = cat + rd[0].ToString();
                    rd.Close();
                    sqlConFill.Close();
                    MessageBox.Show("Item Already Exist at Id " + cat, " ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    sqlConFill.Close();
                    cmdFill.CommandText = "SELECT Cat_Name FROM catagory_list WHERE Cat_Id=@catagoryId4";
                    cmdFill.Parameters.AddWithValue("@catagoryId4", CatagoryIdTxt.Text);
                    cmdFill.Connection = sqlConFill;
                    sqlConFill.Open();
                    rd = cmdFill.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        cat = cat + rd[0].ToString();
                        rd.Close();
                    }
                    sqlConFill.Close();
                    sqlConFill.Close();
                    sqlConFill = new SqlConnection(conn);
                    cmdFill = new SqlCommand();
                    cmdFill.CommandText = "INSERT INTO Foods(Food_Id,Catagory_Id,CatagoryName,FoodName,Price,Description)VALUES (@foodId,@Catagory_Id,@CatagoryName,@FoodName,@Price,@Description)";
                    cmdFill.Parameters.AddWithValue("@foodId", sr.ToString());
                    cmdFill.Parameters.AddWithValue("@Catagory_Id", CatagoryIdTxt.Text);
                    cmdFill.Parameters.AddWithValue("@CatagoryName", cat);
                    cmdFill.Parameters.AddWithValue("@FoodName", FoodNameTxt.Text);
                    cmdFill.Parameters.AddWithValue("@Price", PriceTxt.Text);
                    cmdFill.Parameters.AddWithValue("@Description", DescriptionTxt.Text);
                    cmdFill.Connection = sqlConFill;
                    sqlConFill.Open();
                    cmdFill.ExecuteNonQuery();
                    sqlConFill.Close();
                    Item win2 = new Item();
                    win2.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Food Name, Catagory Id or Price Cann't be Empty", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(FoodIdTxt.Text) && !String.IsNullOrEmpty(CatagoryIdTxt.Text) && !String.IsNullOrEmpty(FoodNameTxt.Text) && !String.IsNullOrEmpty(PriceTxt.Text))
            {
                SqlConnection sqlConFill = new SqlConnection(conn);
                SqlCommand cmdFill = new SqlCommand();
                sqlConFill = new SqlConnection(conn);
                cmdFill = new SqlCommand();
                cmdFill.CommandText = "SELECT Cat_Name FROM catagory_list WHERE Cat_Id=@id";
                cmdFill.Parameters.AddWithValue("@id", CatagoryIdTxt.Text);
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                SqlDataReader rd = cmdFill.ExecuteReader();

                if (rd.HasRows)
                {
                    rd.Read();
                    cat = cat + rd[0].ToString();
                    rd.Close();
                }
                sqlConFill.Close();
                sqlConFill.Close();
                cmdFill.CommandText = "UPDATE Foods SET Catagory_Id=@Catagory_Id,CatagoryName=@CatagoryName,FoodName=@FoodName,Price=@Price,Description=@Description WHERE Food_Id=@Food_Id";
                cmdFill.Parameters.AddWithValue("@Food_Id", FoodIdTxt.Text);
                cmdFill.Parameters.AddWithValue("@Catagory_Id", CatagoryIdTxt.Text);
                cmdFill.Parameters.AddWithValue("@CatagoryName", cat);
                cmdFill.Parameters.AddWithValue("@FoodName", FoodNameTxt.Text);
                cmdFill.Parameters.AddWithValue("@Price", PriceTxt.Text);
                cmdFill.Parameters.AddWithValue("@Description", DescriptionTxt.Text);
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                cmdFill.ExecuteNonQuery();
                sqlConFill.Close();
                Item win2 = new Item();
                win2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Food Name, Catagory Id or Price Cann't be Empty", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(FoodIdTxt.Text))
            {
                SqlConnection sqlConFill = new SqlConnection(conn);
                SqlCommand cmdFill = new SqlCommand();
                cmdFill.CommandText = "DELETE FROM Foods WHERE Food_Id=@Food_Id";
                cmdFill.Parameters.AddWithValue("@Food_Id", FoodIdTxt.Text);
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                cmdFill.ExecuteNonQuery();
                sqlConFill.Close();

                cmdFill.CommandText = "UPDATE Foods SET Food_Id=Food_Id-1 WHERE Food_Id>@Food_Id2";
                cmdFill.Parameters.AddWithValue("@Food_Id2", FoodIdTxt.Text);
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                cmdFill.ExecuteNonQuery();
                sqlConFill.Close();
                Item win2 = new Item();
                win2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Food Id Cann't be Empty", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Manager win2 = new Manager();
            win2.Show();
            this.Close();
        }
    }
}
