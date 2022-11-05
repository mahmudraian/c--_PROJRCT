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
using MySql.Data.MySqlClient;
using System.Data;

     

namespace PharmacyManagement
{
    /// <summary>
    /// Interaction logic for MedicineList.xaml
    /// </summary>
    public partial class MedicineList : Window
    {
        string myConnection = "datasource=localhost;port=3306;username=root;password=;database=pharmacy";
        public MedicineList()
        {
            InitializeComponent();
        }

        private void ADD(object sender, RoutedEventArgs e)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(myConnection);
            mySqlConnection.Open();
            MySqlDataAdapter d = new MySqlDataAdapter("INSERT INTO medicinelist(Name,TotalQuantity,Price)VALUES('" + this.Medicine_name.Text + "','" + this.Totalquantity.Text + "','" + this.Price.Text + "')", mySqlConnection);
            d.SelectCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Insert Successful!");
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection mySqlConnection = new MySqlConnection(myConnection);
            mySqlConnection.Open();
            MySqlDataAdapter d = new MySqlDataAdapter("select * from medicinelist;", mySqlConnection);
            DataTable data = new DataTable("sales");
            d.Fill(data);
            datagrid.ItemsSource = data.DefaultView;
            //d.SelectCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            /*try
            {

                //string myConnection = "datasource=localhost;port=3306;username=root;password=;database=pharmacy";

                MySqlConnection mySqlConnection = new MySqlConnection(myConnection);
                MySqlCommand SelectCommand = new MySqlCommand("select * from sales;", mySqlConnection);
                MySqlDataReader myReader;

                mySqlConnection.Open();
                //myReader = SelectCommand.ExecuteReader();
                myReader = SelectCommand.ExecuteReader();
                MySqlDataAdapter da = new MySqlDataAdapter(SelectCommand);
                DataTable dt = new DataTable("medicinelist");
                da.Fill(dt);
                datagrid.ItemsSource = dt.DefaultView;
                da.Update(dt);
                //myReader = SelectCommand.ExecuteReader();
                if (myReader.Read())
                {
                    MessageBox.Show("Username and Password is correct!");
                }
                else
                {
                    MessageBox.Show("invalid username or password!");
                }
                mySqlConnection.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }
    }
}
