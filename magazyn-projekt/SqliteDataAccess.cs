
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static magazyn_projekt.ManageUsers;
using System.Collections.ObjectModel;
using static magazyn_projekt.removeUserPopup;
using static magazyn_projekt.deleteItemPopup;

namespace magazyn_projekt
{
    
    public class SqliteDataAccess
    {
        public static List<userModel> users = new List<userModel>();
        public static List<itemModel> items = new List<itemModel>();
        public static List<userModel> newbies  = new List<userModel>();
        public static List<userModel> removedUsers = new List<userModel>();
        public static ObservableCollection<userModel> observableUsers = new ObservableCollection<userModel>();
        public static ObservableCollection<itemModel> observableItems = new ObservableCollection<itemModel>();
        public static List<userModel> loadUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<userModel> ("select * from users", new DynamicParameters());
                return output.ToList();
            }
           
        }
        public static List<itemModel> loadItems()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<itemModel>("select * from items", new DynamicParameters());
                return output.ToList();
            }

        }

        public static void saveUsers(userModel newbs)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into users (userid, password, status, firstname, lastname, mail, address ) values(@userid, @password, @status, @firstname, @lastname, @mail, @address)", newbs);
            }
        }
        public static void deleteUsers()
        {
            string removecommand = "delete from users where id='" + removeUserPopup.removeId + "'";
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {

                cnn.Execute(removecommand);
            }
        }
        public static void updateUsers()
        {
            string updateCommand = "update users set " + editUserPopup.whatToEdit + "='" + editUserPopup.editContent + "' where id='" + editUserPopup.editID +"'" ;
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute(updateCommand);
            }
        }

        private static string loadConnectionString(string pepega = "trololo")
        {
            return ConfigurationManager.ConnectionStrings[pepega].ConnectionString;
        }
        public static void addItem(itemModel newbs)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into items (idDos, nazwaTow, ilosc, cenaZak, cenaSprz ) values(@idDos, @nazwaTow, @ilosc, @cenaZak, @cenaSprz)", newbs);
            }
        }

        public static void deleteItems()
        {
            string removecommand = "delete from items where id='" + deleteItemPopup.removeItID + "'";
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {

                cnn.Execute(removecommand);
            }
        }
        public static void editItems()
        {
            string updateCommand = "update items set " + editItemPopup.whatToEdit + "='" + editItemPopup.editContent + "' where idTow='" + editItemPopup.editID + "'";
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute(updateCommand);
            }
        }
    }
}
