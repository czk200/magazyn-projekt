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
using static magazyn_projekt.SqliteDataAccess;

namespace magazyn_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy AddItemPopup.xaml
    /// </summary>
    public partial class AddItemPopup : Window
    {
        public AddItemPopup()
        {
            InitializeComponent();
        }

        private void addItemButton_Click(object sender, RoutedEventArgs e)
        {
            itemModel p = new itemModel();
            p.idDos = Int32.Parse(supplierIdTextBox.Text);
            p.ilosc = Int32.Parse(itemQuantityTextBox.Text);
            p.nazwaTow = itemNameTextBox.Text;
            p.cenaZak = float.Parse(buyingPriceTextBox.Text);
            p.cenaSprz = float.Parse(sellingPriceTextBox.Text);
            SqliteDataAccess.addItem(p);
            supplierIdTextBox.Text = "";
            itemQuantityTextBox.Text = "";
            itemNameTextBox.Text = "";
            sellingPriceTextBox.Text = "";
            buyingPriceTextBox.Text = "";
            items = SqliteDataAccess.loadItems();
        }
    }
}

