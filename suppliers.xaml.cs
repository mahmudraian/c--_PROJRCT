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
    /// Interaction logic for suppliers.xaml
    /// </summary>
    public partial class suppliers : Window
    {
        string myConnection = "datasource=localhost;port=3306;username=root;password=;database=pharmacy";
        public suppliers()
        {
            InitializeComponent();
        }

        private void ADD(object sender, RoutedEventArgs e)
        {
            

                //string myConnection = "datasource=localhost;port=3306;username=root;password=;database=pharmacy";

                MySqlConnection mySqlConnection = new MySqlConnection(myConnection);
            MySqlDataAdapter d = new MySqlDataAdapter("INSERT INTO supplierlist(SupplierId,Details)VALUES('" + this.suppliers_id.Text + "','" + this.Details.Text + "')", mySqlConnection);
            mySqlConnection.Open();
            d.SelectCommand.ExecuteNonQuery();

                mySqlConnection.Close();
                MessageBox.Show("Insert Successful!");
            }

        private void Load_Click(object sender, RoutedEventArgs e)
        {


                MySqlConnection mySqlConnection = new MySqlConnection(myConnection);
                mySqlConnection.Open();
                MySqlDataAdapter d = new MySqlDataAdapter("select * from supplierlist;", mySqlConnection);
                DataTable data = new DataTable("sales");
                d.Fill(data);
               datagrid.ItemsSource = data.DefaultView;
               //d.SelectCommand.ExecuteNonQuery();
               mySqlConnection.Close();

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
    

