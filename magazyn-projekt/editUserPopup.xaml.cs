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
using static magazyn_projekt.ManageUsers;
using static magazyn_projekt.SqliteDataAccess;

namespace magazyn_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy editUserPopup.xaml
    /// </summary>
    public partial class editUserPopup : Window
    {
        public static string whatToEdit;
        public static string editContent;
        public static string editID;
        public editUserPopup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            whatToEdit = "userid";
            editContent = editLoginTextBox.Text;
            editID = editIdTextBox.Text;
            checker();
            users = loadUsers();
            
            
        }

        private void editPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            whatToEdit = "password";
            editContent = editPasswordTextBox.Text;
            editID = editIdTextBox.Text;
            checker();
            users = loadUsers();
        }

        private void editStatusButton_Click(object sender, RoutedEventArgs e)
        {
            whatToEdit = "status";
            editContent = editStatusTextBox.Text;
            editID = editIdTextBox.Text;
            checker();
            users = loadUsers();
        }

        private void checker()
        {
            try
            {
                SqliteDataAccess.updateUsers();
            }
            catch
            {
                this.Title = "something wrong happened uwo, check your input";
                Task.Delay(2000).ContinueWith(t => this.Title = "Add Item");
            }
        }
    }
}
