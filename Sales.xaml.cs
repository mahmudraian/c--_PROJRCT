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
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        string myConnection = "datasource=localhost;port=3306;username=root;password=;database=pharmacy";
        //MySqlConnection mySqlConnection = new MySqlConnection(myConnection);
        public Sales()
        {
            InitializeComponent();
            //data collect and show in datagridview
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Close();
        }
        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(myConnection);
            mySqlConnection.Open();
            MySqlDataAdapter d = new MySqlDataAdapter("INSERT INTO sales(Sales_date, Medicine, Quantity)VALUES('" + this.Saledate.Text + "', '" + this.Medicine_name.Text + "', '" + this.Total.Text + "')", mySqlConnection);
            MySqlDataReader myReader;
            d.SelectCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Insert Successful!");
        }

        private void LOAD_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(myConnection);
            mySqlConnection.Open();
            MySqlDataAdapter d = new MySqlDataAdapter("select * from sales;", mySqlConnection);
            DataTable data = new DataTable("sales");
            d.Fill(data);
            datagrid.ItemsSource = data.DefaultView;
            d.SelectCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection newmySqlConnection = new MySqlConnection(myConnection);
            newmySqlConnection.Open();
            MySqlDataAdapter d = new MySqlDataAdapter("Update sales Set Sales_date='" + this.Saledate.Text +"'Medicine= '"+this.Medicine_name +"',Quantity='" + this.Total.Text + "'Where Sales_date='" + this.Saledate.Text+"' Medicine='"+this.Medicine_name.Text+"'and Quantity='"+this.Total.Text+"')'",newmySqlConnection);
         
            d.SelectCommand.ExecuteNonQuery();
            int rowsAffected = d.ExecuteNonQuery();
            newmySqlConnection.Close();
            MessageBox.Show("update Successful!");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
