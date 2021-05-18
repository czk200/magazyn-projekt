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
        public static string userLevel;
        public loginWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string login = loginBox.Text;
            string password = passwordBox.Text;

            if (string.IsNullOrEmpty(login)) { MessageBox.Show("Uzupełnij login"); return; }
            if (string.IsNullOrEmpty(password)) { MessageBox.Show("Uzupełnij hasło"); return; }

            users = SqliteDataAccess.loadUsers();
            items = SqliteDataAccess.loadItems();
            userModel user = users.FirstOrDefault(x => x.userid.Equals(login));

            if (user != null && user.password.Equals(password))
            {
                Hide();
                if (user.status.Equals("0"))
                {
                    userLevel = "0";
                    CustomerWindow window = new CustomerWindow();
                    window.Show();
                    window.Focus();

                }
                else if (user.status.Equals("1"))
                {
                    userLevel = "1";
                    MainWindow window = new MainWindow();
                    window.Show();
                    window.Focus();
                }
                else if (user.status.Equals("2"))
                {
                    userLevel = "2";
                    MainWindow window = new MainWindow();
                    window.Show();
                    window.Focus();
                }
                else if (user.status.Equals("3"))
                {
                    userLevel = "3";
                    MainWindow window = new MainWindow();
                    window.Show();
                    window.Focus();
                }
            }
            else { loginInfo.Text = "Nieprawidłowy login i/lub hasło"; }
        }

        private void ButtonAddCustomerClick(object sender, RoutedEventArgs e)
        {
            AddCustomerPopup window = new AddCustomerPopup();
            window.ShowDialog();
        }

        private void ButtonExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
