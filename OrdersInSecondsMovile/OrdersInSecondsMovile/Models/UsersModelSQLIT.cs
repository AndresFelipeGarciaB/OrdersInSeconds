using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersInSecondsMovile.Models
{
    public class UsersModelSQLIT
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string user { get; set; }
        public string Pass { get; set; }
    }
}
