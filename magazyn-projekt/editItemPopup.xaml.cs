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

namespace magazyn_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy editItemPopup.xaml
    /// </summary>
    public partial class editItemPopup : Window
    {
        public static string whatToEdit;
        public static string editContent;
        public static string editID;
        public editItemPopup()
        {
            InitializeComponent();
        }

        private void changeItNameBtn_Click(object sender, RoutedEventArgs e)
        {
            whatToEdit = "nazwaTow";
            editContent = changeItNameTextBox.Text;
            editID = editIdTextBox.Text;
            checker();
            SqliteDataAccess.items = SqliteDataAccess.loadItems();
        }

        private void changeItSPriceBtn_Click(object sender, RoutedEventArgs e)
        {
            whatToEdit = "cenaSprz";
            editContent = changeItSPriceTo.Text;
            editID = editIdTextBox.Text;
            checker();
            SqliteDataAccess.items = SqliteDataAccess.loadItems();
        }

        private void changeItBPriceBtn_Click(object sender, RoutedEventArgs e)
        {
            whatToEdit = "cenaZak";
            editContent = changeItBPriceTo.Text;
            editID = editIdTextBox.Text;
            checker();
            SqliteDataAccess.items = SqliteDataAccess.loadItems();
        }

        private void changeItQtyBtn_Click(object sender, RoutedEventArgs e)
        {
            whatToEdit = "ilosc";
            editContent = changeItQuantityTo.Text;
            editID = editIdTextBox.Text;
            checker();
            SqliteDataAccess.items = SqliteDataAccess.loadItems();
        }

        private void changeItSupplierBtn_Click(object sender, RoutedEventArgs e)
        {
            whatToEdit = "idDos";
            editContent = changeItSupplierto.Text;
            editID = editIdTextBox.Text;
            checker();
            SqliteDataAccess.items = SqliteDataAccess.loadItems();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void checker()
        {
            try
            {
                SqliteDataAccess.editItems();
            }
            catch
            {
                this.Title = "something wrong happened uwo, check your input";
            }
        }
    }
}
