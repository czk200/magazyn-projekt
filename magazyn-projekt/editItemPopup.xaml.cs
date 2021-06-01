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
        int intDummy;
        float floatDummy;
        public editItemPopup()
        {
            InitializeComponent();
        }

        private void changeItNameBtn_Click(object sender, RoutedEventArgs e)
        {
            prechecker();
            if(changeItNameTextBox.Text!="")
            {
                whatToEdit = "nazwaTow";
                editContent = changeItNameTextBox.Text;
                editID = editIdTextBox.Text;
                checker();
                SqliteDataAccess.items = SqliteDataAccess.loadItems();

            }
            else pepegaWait();

        }

        private void changeItSPriceBtn_Click(object sender, RoutedEventArgs e)
        {
            if(changeItSPriceTo.Text!="")
            {
                prechecker();
                whatToEdit = "cenaSprz";
                editContent = changeItSPriceTo.Text.Replace(",", ".");
                editID = editIdTextBox.Text;
                checker();
                SqliteDataAccess.items = SqliteDataAccess.loadItems();

            }
            else pepegaWait();

        }

        private void changeItBPriceBtn_Click(object sender, RoutedEventArgs e)
        {
            if(changeItBPriceTo.Text!="")
            {
                prechecker();
                whatToEdit = "cenaZak";
                editContent = changeItBPriceTo.Text.Replace(",", ".");
                editID = editIdTextBox.Text;
                checker();
                SqliteDataAccess.items = SqliteDataAccess.loadItems();
            }
            else pepegaWait();

        }

        private void changeItQtyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (changeItQuantityTo.Text != "")
            {
                prechecker();
                whatToEdit = "ilosc";
                editContent = changeItQuantityTo.Text;
                editID = editIdTextBox.Text;
                checker();
                SqliteDataAccess.items = SqliteDataAccess.loadItems();
            }
            else pepegaWait();
            
        }

        private void changeItSupplierBtn_Click(object sender, RoutedEventArgs e)
        {
            if(changeItSupplierto.Text!="")
            {
                whatToEdit = "idDos";
                try
                {
                    intDummy= Int32.Parse(changeItSupplierto.Text);
                }
                catch
                {
                    pepegaWait();
                }
                editContent = changeItSupplierto.Text;
                editID = editIdTextBox.Text;
                checker();
                SqliteDataAccess.items = SqliteDataAccess.loadItems();
            }
            else pepegaWait();

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
                async Task pepegaWait()
                {
                    this.Title = "something wrong happened uwo, check your input";
                    var t1 = Task.Delay(2000);
                    await t1;
                    this.Title = "Edit Item";

                }
                pepegaWait();

            }
        }
        async Task pepegaWait()
        {
            this.Title = "something wrong happened uwo, check your input";
            var t1 = Task.Delay(2000);
            await t1;
            this.Title = "Edit Item";

        }
        private void prechecker()
        {
            if (editIdTextBox.Text == "")
            {               
                pepegaWait();
            }
        }

    }
}
