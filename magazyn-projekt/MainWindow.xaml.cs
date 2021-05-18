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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Controls.Menu;
using static magazyn_projekt.SqliteDataAccess;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Data;
using static magazyn_projekt.loginWindow;

namespace magazyn_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer1;
        public static ObservableCollection<itemModel> obervableItems = new ObservableCollection<itemModel>(items);
        public MainWindow()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = observableItems;
            InitTimer();
            if (loginWindow.userLevel != "3")
            {
                if (loginWindow.userLevel != "2")
                {
                    manageUsersButton.IsEnabled = false;
                    deleteItemButton.IsEnabled = false;
                }
            }
        }
        private void addUserButtonClick(object sender, RoutedEventArgs e)
        {
            ManageUsers mW = new ManageUsers();
            this.Hide();
            mW.Show();
            mW.Focus();
        }
        
       
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            ObservableCollection<itemModel> observableItems = new ObservableCollection<itemModel>(items);
            dataGrid1.ItemsSource = null;
            if(searchBar.Text!="")
            {
                var filter = items.Where(itemModel => itemModel.nazwaTow.StartsWith(searchBar.Text));
                dataGrid1.ItemsSource = filter;
            }
            else
            {
                dataGrid1.ItemsSource = observableItems;
            }
            
        }

        private void addItemButton_Click(object sender, RoutedEventArgs e)
        {
            AddItemPopup addItPop = new AddItemPopup();
            addItPop.Show();
        }

        private void deleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            deleteItemPopup delItPop = new deleteItemPopup();
            delItPop.Show();
        }

        private void editItemButton_Click(object sender, RoutedEventArgs e)
        {
            editItemPopup edItPop = new editItemPopup();
            edItPop.Show();
        }

        private void searchBar_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
