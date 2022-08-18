using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersInSecondsMovile.Models
{
   
    
    public class RatingModel
    {
        public double rate { get; set; }
        public int count { get; set; }
        public string starImage { get; set; }
    }

    public class DataApiModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public RatingModel rating { get; set; }
    }


}
