using System;
using System.Threading.Tasks;
using System.Windows;
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
            if (supplierIdTextBox.Text != "") p.idDos = Int32.Parse(supplierIdTextBox.Text);
            if (itemQuantityTextBox.Text != "") p.ilosc = Int32.Parse(itemQuantityTextBox.Text);
            if (itemNameTextBox.Text != "") p.nazwaTow = itemNameTextBox.Text;
            if (buyingPriceTextBox.Text != "") p.cenaZak = float.Parse(buyingPriceTextBox.Text);
            if (sellingPriceTextBox.Text != "") p.cenaSprz = float.Parse(sellingPriceTextBox.Text);
            try
            {
                SqliteDataAccess.addItem(p);
            }
            catch
            {
                async Task pepegaWait()
                {
                    this.Title = "something wrong happened uwo, check your input";
                    var t1 = Task.Delay(2000);
                    await t1;
                    this.Title = "Add Item";

                }
                pepegaWait();

            }
            supplierIdTextBox.Text = "";
            itemQuantityTextBox.Text = "";
            itemNameTextBox.Text = "";
            sellingPriceTextBox.Text = "";
            buyingPriceTextBox.Text = "";
            items = SqliteDataAccess.loadItems();
        }
    }
}

