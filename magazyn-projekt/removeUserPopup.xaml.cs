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
using static magazyn_projekt.ManageUsers;
using System.Collections.ObjectModel;

namespace magazyn_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy removeUserPopup.xaml
    /// </summary>
    public partial class removeUserPopup : Window
    {
        public static string removeId;
        public removeUserPopup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(removeidTexbox.Text!="1")
            {
                removeId = removeidTexbox.Text;
                try
                {
                    SqliteDataAccess.deleteUsers();
                }
                catch
                {
                    this.Title = "something wrong happened uwo, check your input";
                    Task.Delay(2000).ContinueWith(t => this.Title = "Add Item");
                }
                users = SqliteDataAccess.loadUsers();
            }
            
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
