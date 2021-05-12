using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magazyn_projekt
{
    public class userModel
    {
        public int id { get; set; }
        public string status { get; set; }
        public string userid { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public string address { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }

    public class itemModel
    {
        public int idTow { get; set; }
        public int idDos { get; set; }
        public string nazwaTow { get; set; }
        public int ilosc { get; set; }
        public float cenaZak { get; set; }
        public float cenaSprz { get; set; }
    }

}
