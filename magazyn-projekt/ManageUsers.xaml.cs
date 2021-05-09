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
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows.Threading;

namespace magazyn_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy menageUsers.xaml
    /// </summary>

    public partial class ManageUsers : Window
    {
        public static ObservableCollection<userModel> observableUsers = new ObservableCollection<userModel>(users);
        private DispatcherTimer timer1;
        public ManageUsers()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = observableUsers;
            InitTimer();
        }
        
        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            this.Hide();
            mW.Show();
            mW.Focus();
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            adduserPopup adduserPopWin = new adduserPopup();
            adduserPopWin.Show();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            removeUserPopup remusPop = new removeUserPopup();
            remusPop.Show();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void InitTimer()
        {
            timer1 = new DispatcherTimer();
            timer1.Tick += new EventHandler(timer1_Tick);
            TimeSpan ts = TimeSpan.FromMilliseconds(33);
            timer1.Interval = ts;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ObservableCollection<userModel> observableUsers = new ObservableCollection<userModel>(users);
            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = observableUsers;
        }

        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {
            editUserPopup edUsPop = new editUserPopup();
            edUsPop.Show();
        }
    }
}
