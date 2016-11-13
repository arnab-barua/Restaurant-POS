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
    /// Interaction logic for Catagory.xaml
    /// </summary>
    public partial class Catagory : Window
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public Catagory()
        {
            InitializeComponent();
            SqlConnection sqlConFill = new SqlConnection(conn);
            SqlCommand cmdFill = new SqlCommand();
            cmdFill.CommandText = "SELECT * FROM catagory_list ORDER BY Cat_Id";
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmdFill);
            DataTable dt = new DataTable("Catagory");
            sda.Fill(dt);
            grdCatagory.ItemsSource = dt.DefaultView;
            sqlConFill.Close();
        }

        private void change(object sender, RoutedEventArgs e)
        {
            String txt = Convert.ToString(((DataRowView)grdCatagory.SelectedItem)["Cat_Id"]);
            if (txt != null)
            {
                CatagoryIdTxt.Text = Convert.ToString(((DataRowView)grdCatagory.SelectedItem)["Cat_Id"]);
                CatagoryNameTxt.Text = Convert.ToString(((DataRowView)grdCatagory.SelectedItem)["Cat_Name"]);
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CatagoryNameTxt.Text))
            {
                int sr = 0;
                SqlConnection sqlConFill = new SqlConnection(conn);
                SqlCommand cmdFill = new SqlCommand();
                cmdFill.CommandText = "SELECT MAX(Cat_Id) FROM catagory_list";
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

                cmdFill.CommandText = "SELECT Cat_Id FROM catagory_list WHERE Cat_Name=@Name";
                cmdFill.Parameters.AddWithValue("@Name", CatagoryNameTxt.Text);
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
                    MessageBox.Show("Food Catagory Already Exist at Id " + cat, " ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    sqlConFill.Close();
                    sqlConFill = new SqlConnection(conn);
                    cmdFill = new SqlCommand();
                    cmdFill.CommandText = "INSERT INTO catagory_list(Cat_Id,Cat_Name) VALUES (@CatagoryId,@CatagoryName)";
                    cmdFill.Parameters.AddWithValue("@CatagoryId", sr.ToString());
                    cmdFill.Parameters.AddWithValue("@CatagoryName", CatagoryNameTxt.Text);
                    cmdFill.Connection = sqlConFill;
                    sqlConFill.Open();
                    cmdFill.ExecuteNonQuery();
                    sqlConFill.Close();
                    Catagory win2 = new Catagory();
                    win2.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Catagory Name Cann't be Empty", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CatagoryIdTxt.Text) && !String.IsNullOrEmpty(CatagoryNameTxt.Text))
            {
                SqlConnection sqlConFill = new SqlConnection(conn);
                SqlCommand cmdFill = new SqlCommand();
                cmdFill.CommandText = "UPDATE catagory_list SET Cat_Id=@CatagoryId,Cat_Name=@CatagoryName WHERE Cat_Id=@CatagoryId";
                cmdFill.Parameters.AddWithValue("@CatagoryId", CatagoryIdTxt.Text);
                cmdFill.Parameters.AddWithValue("@CatagoryName", CatagoryNameTxt.Text);
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                cmdFill.ExecuteNonQuery();
                sqlConFill.Close();
                Catagory win2 = new Catagory();
                win2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Catagory Id or Name Cann't be Empty", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CatagoryIdTxt.Text) && !String.IsNullOrEmpty(CatagoryNameTxt.Text))
            {
                SqlConnection sqlConFill = new SqlConnection(conn);
                SqlCommand cmdFill = new SqlCommand();
                cmdFill.CommandText = "DELETE FROM catagory_list WHERE Cat_Id=@CatagoryId";
                cmdFill.Parameters.AddWithValue("@CatagoryId", CatagoryIdTxt.Text);
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                cmdFill.ExecuteNonQuery();
                sqlConFill.Close();

                SqlConnection sqlConFilld = new SqlConnection(conn);
                SqlCommand cmdFilld = new SqlCommand();
                cmdFilld.CommandText = "DELETE FROM Foods WHERE Catagory_Id=@dCatagoryIde";
                cmdFilld.Parameters.AddWithValue("@dCatagoryIde", CatagoryIdTxt.Text);
                cmdFilld.Connection = sqlConFilld;
                sqlConFilld.Open();
                cmdFilld.ExecuteNonQuery();
                sqlConFilld.Close();

                cmdFill.CommandText = "UPDATE catagory_list SET Cat_Id=Cat_Id-1 WHERE Cat_Id>@CatagoryId2";
                cmdFill.Parameters.AddWithValue("@CatagoryId2", CatagoryIdTxt.Text);
                cmdFill.Connection = sqlConFill;
                sqlConFill.Open();
                cmdFill.ExecuteNonQuery();
                sqlConFill.Close();

                SqlConnection sqlConFilluf = new SqlConnection(conn);
                SqlCommand cmdFilluf = new SqlCommand();
                cmdFilluf.CommandText = "UPDATE Foods SET Catagory_Id=Catagory_Id-1 WHERE Catagory_Id>@CatagoryIduf";
                cmdFilluf.Parameters.AddWithValue("@CatagoryIduf", CatagoryIdTxt.Text);
                cmdFilluf.Connection = sqlConFilluf;
                sqlConFilluf.Open();
                cmdFilluf.ExecuteNonQuery();
                sqlConFilluf.Close();
                Catagory win2 = new Catagory();
                win2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Catagory Id or Name Cann't be Empty");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConFill = new SqlConnection(conn);
            SqlCommand cmdFill = new SqlCommand();
            cmdFill.CommandText = "SELECT MAX(Cat_Id) FROM catagory_list";
            cmdFill.Parameters.AddWithValue("@CatagoryId", CatagoryIdTxt.Text);
            cmdFill.Connection = sqlConFill;
            sqlConFill.Open();
            int sr = 0;
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
            if (sr > 0)
            {
                for (int i = 1; i <= sr; i++)
                {
                    SqlConnection sqlConFill2 = new SqlConnection(conn);
                    SqlCommand cmdFill2 = new SqlCommand();
                    cmdFill2.CommandText = "SELECT Cat_Name FROM catagory_list WHERE Cat_Id=@catId3";
                    cmdFill2.Parameters.AddWithValue("@catId3", Convert.ToString(i));
                    cmdFill2.Connection = sqlConFill2;
                    sqlConFill2.Open();
                    SqlDataReader rd3 = cmdFill2.ExecuteReader();
                    String cat = "";
                    if (rd3.HasRows)
                    {
                        rd3.Read();
                        cat = cat + rd3[0].ToString();
                        rd3.Close();
                        sqlConFill2.Close();
                        SqlConnection sqlUpdate = new SqlConnection(conn);
                        SqlCommand cmdUpdate = new SqlCommand();
                        cmdUpdate.CommandText = "UPDATE Foods SET CatagoryName=@CatagoryName WHERE Catagory_Id=@Catagory_Id";
                        cmdUpdate.Parameters.AddWithValue("@Catagory_Id", Convert.ToString(i));
                        cmdUpdate.Parameters.AddWithValue("@CatagoryName", cat);
                        cmdUpdate.Connection = sqlUpdate;
                        sqlUpdate.Open();
                        cmdUpdate.ExecuteNonQuery();
                        sqlUpdate.Close();
                    }
                }
            }

            //reordering item id
            SqlConnection sqlMaxSearch = new SqlConnection(conn);
            SqlCommand cmdMaxSearch = new SqlCommand();
            cmdMaxSearch.CommandText = "SELECT COUNT(*) FROM Foods";
            cmdMaxSearch.Connection = sqlMaxSearch;
            sqlMaxSearch.Open();
            int ct = 0;
            SqlDataReader rdmax = cmdMaxSearch.ExecuteReader();
            if (rdmax.HasRows)
            {
                rdmax.Read();
                var outputParam = rdmax[0];
                if (!(outputParam is DBNull))
                {
                    ct = Convert.ToInt32(rdmax[0]);
                }
                else
                {
                    ct = 0;
                }
                rdmax.Close();
            }
            sqlMaxSearch.Close();
            if (ct > 0)
            {
                SqlConnection sqlAllRow = new SqlConnection(conn);
                SqlCommand cmdAllRow = new SqlCommand();
                cmdAllRow.CommandText = "SELECT Food_Id FROM Foods";
                cmdAllRow.Connection = sqlAllRow;
                sqlAllRow.Open();
                SqlDataReader rdAllRow = cmdAllRow.ExecuteReader();
                String cat = "";
                int i = 1;
                if (rdAllRow.HasRows)
                {
                    while (rdAllRow.Read())
                    {
                        cat = rdAllRow[0].ToString();
                        SqlConnection sqlUpdateItem = new SqlConnection(conn);
                        SqlCommand cmdUpdateItem = new SqlCommand();
                        cmdUpdateItem.CommandText = "UPDATE Foods SET Food_Id=@foodIdUpdated WHERE Food_Id=@foodIdOld";
                        cmdUpdateItem.Parameters.AddWithValue("@foodIdUpdated", Convert.ToString(i));
                        cmdUpdateItem.Parameters.AddWithValue("@foodIdOld", cat);
                        cmdUpdateItem.Connection = sqlUpdateItem;
                        sqlUpdateItem.Open();
                        cmdUpdateItem.ExecuteNonQuery();
                        sqlUpdateItem.Close();
                        i++;
                    }
                    rdAllRow.Close();
                    sqlAllRow.Close();
                }
                sqlAllRow.Close();
            }

            Manager win2 = new Manager();
            win2.Show();
            this.Close();
        }
    }
}
