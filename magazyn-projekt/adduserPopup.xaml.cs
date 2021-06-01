using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace magazyn_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy adduserPopup.xaml
    /// </summary>
    public partial class adduserPopup : Window
    {
        public adduserPopup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userModel p = new userModel();
            if (loginWindow.userLevel == "2" && ComboBox.SelectedItem != "1")
                    {
                        this.Title = "manager can only add workers, correct your input please";
                    }
            else
                    {
                        p.status = ComboBox.SelectedIndex.ToString();
                        if (useridTextBox.Text != "") p.userid = useridTextBox.Text;
                        if (userpasswordTextBox.Text != "") p.password = userpasswordTextBox.Text;
                        p.address = "";
                        SqliteDataAccess.saveUsers(p);
                        pepegaWait();

                    }

                           
            useridTextBox.Text = "";
            userpasswordTextBox.Text = "";
            users = SqliteDataAccess.loadUsers();
        }
        async Task pepegaWait()
        {
            this.Title = "something wrong happened uwo, check your input";
            var t1 = Task.Delay(2000);
            await t1;
            this.Title = "Delete Item";

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
