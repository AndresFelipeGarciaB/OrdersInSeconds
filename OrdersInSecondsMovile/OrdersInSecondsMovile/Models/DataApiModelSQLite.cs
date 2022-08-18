using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersInSecondsMovile.Models
{
   

    public class DataApiModelSQLite
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public double rate { get; set; }
        public int count { get; set; }
    }


}
