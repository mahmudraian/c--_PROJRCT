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

namespace PharmacyManagement
{
    /// <summary>
    /// Interaction logic for LOGIN.xaml
    /// </summary>
    public partial class LOGIN : Window
    {
        // MySqlConnection connection = new MySqlConnection();
        //Dashboard d = null;
        public LOGIN()
        {
            InitializeComponent();
        }

        private void Btnlogin_Click(object sender, RoutedEventArgs e)
        {
            //Dashboard d = new Dashboard();
            //d.Show();
            try
            {

                string myConnection = "datasource=localhost;port=3306;username=root;password=;database=pharmacy";

                MySqlConnection mySqlConnection = new MySqlConnection(myConnection);
                MySqlCommand SelectCommand = new MySqlCommand("select * from login where ID='" + this.user_name.Text + "' and Password='" + this.user_password.Password + "' ;", mySqlConnection);
                MySqlDataReader myReader;

                mySqlConnection.Open();
                myReader = SelectCommand.ExecuteReader();

                //int count = 0;


                //while(myReader.Read())
                //{
                //    count = count + 1;
                //}
                if (myReader.Read())
                {
                    MessageBox.Show("Username and Password is correct!");
                    Dashboard d = new Dashboard();
                    d.Show();
                    this.Close();
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
            }
        }

        private void Txtusername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
