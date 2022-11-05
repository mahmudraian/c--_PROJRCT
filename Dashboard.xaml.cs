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

namespace PharmacyManagement
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Sales_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sales s = new Sales();
            s.Show();
            this.Close();
        }

        private void Medicinebutton_Click(object sender, RoutedEventArgs e)
        {
            MedicineList ml = new MedicineList();
            ml.Show();
            this.Close();
        }

        private void Supplierbutton_Click(object sender, RoutedEventArgs e)
        {
            suppliers s = new suppliers();
            s.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //Dashboard d = new Dashboard();
            Close();
            
        }

        private void back(object sender, RoutedEventArgs e)
        {
            LOGIN l = new LOGIN();
            l.Show();
            this.Close();
        }

        private void Exit_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
