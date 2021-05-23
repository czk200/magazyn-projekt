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
using static magazyn_projekt.removeUserPopup;
using static magazyn_projekt.MainWindow;

namespace magazyn_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy deleteItemPopup.xaml
    /// </summary>
    public partial class deleteItemPopup : Window
    {
        public static string removeItID;
        public deleteItemPopup()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void deleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            removeItID = deleteItIDTextBox.Text;
            try
            {
                SqliteDataAccess.deleteItems();
            }
            catch
            {
                this.Title = "something wrong happened uwo, check your input";
                Task.Delay(2000).ContinueWith(t => this.Title = "Add Item");
            }
            SqliteDataAccess.items = SqliteDataAccess.loadItems();
        }
    }
}
