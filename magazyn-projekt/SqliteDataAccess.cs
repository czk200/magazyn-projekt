
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


namespace magazyn_projekt
{
    
    public class SqliteDataAccess
    {
        public static List<userModel> users;
        public static List<userModel> loadUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<userModel> ("select * from users", new DynamicParameters());
                return output.ToList();
            }
           
        }
        private static string loadConnectionString(string pepega = "trololo")
        {
            return ConfigurationManager.ConnectionStrings[pepega].ConnectionString;
        }
    }
}
