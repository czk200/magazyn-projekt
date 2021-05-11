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
    public partial class AddCustomerPopup : Window
    {
        public AddCustomerPopup()
        {
            InitializeComponent();
        }

        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            userModel newCustomer = new userModel();
            newCustomer.firstname = FirstnameTextBox.Text;
            newCustomer.lastname = LastnameTextBox.Text;
            newCustomer.userid = LoginTextBox.Text;
            newCustomer.password = PasswordTextBox.Text;
            newCustomer.status = "0";
            newCustomer.mail = EmailTextBox.Text;
            newCustomer.address = AddressTextBox.Text;

            if (string.IsNullOrEmpty(newCustomer.firstname)) { MessageBox.Show("Uzupełnij imię"); return; }
            if (string.IsNullOrEmpty(newCustomer.lastname)) { MessageBox.Show("Uzupełnij nazwisko"); return; }
            if (string.IsNullOrEmpty(newCustomer.userid)) { MessageBox.Show("Uzupełnij login"); return; }
            if (string.IsNullOrEmpty(newCustomer.password)) { MessageBox.Show("Uzupełnij hasło"); return; }
            if (string.IsNullOrEmpty(newCustomer.mail)) { MessageBox.Show("Uzupełnij mail"); return; }
            if (string.IsNullOrEmpty(newCustomer.address)) { MessageBox.Show("Uzupełnij adres"); return; }

            SqliteDataAccess.saveUsers(newCustomer);
            users = SqliteDataAccess.loadUsers();
            MessageBox.Show($"Popawnie dodano: {newCustomer.userid}");
            Close();
        }

        private void ButtonCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
