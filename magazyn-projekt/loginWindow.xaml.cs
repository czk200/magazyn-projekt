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
    public partial class loginWindow : Window
    {
        public loginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userid = loginBox.Text;
            string password = passwordBox.Text;
            users = SqliteDataAccess.loadUsers();
            items = SqliteDataAccess.loadItems();
            userModel user = users.FirstOrDefault(x => x.userid.Equals(userid));

            if (user != null && user.password.Equals(password))
            {
                Hide();
                if (user.status.Equals("0"))
                {
                    CustomerWindow window = new CustomerWindow();
                    window.Show();
                    window.Focus();
                }
                else
                {
                    MainWindow window = new MainWindow();
                    window.Show();
                    window.Focus();
                }
            }
            else { loginLabel.Content = "Nieprawidłowy login i/lub hasło"; }
        }

        private void ButtonAddCustomerClick(object sender, RoutedEventArgs e)
        {
            AddCustomerPopup window = new AddCustomerPopup();
            window.ShowDialog();
        }
    }
}
