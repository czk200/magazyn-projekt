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
    /// Logika interakcji dla klasy loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        int statusLevel;
        public loginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             
            string allegedId = loginBox.Text;
            users = SqliteDataAccess.loadUsers();
            int index = users.FindIndex(users => users.userid == allegedId);
            if (index != -1)
            {
                if (passwordBox.Text == users[index].password)
                {
                    statusLevel = users[index].status;
                    MainWindow mW = new MainWindow();
                    this.Hide();
                    mW.Show();
                    mW.Focus();
                }
                else { loginLabel.Content = "Nieprawidłowy login i/lub hasło"; }
            }
            else { loginLabel.Content = "Nieprawidłowy login i/lub hasło"; }
            

        }
    }
}
