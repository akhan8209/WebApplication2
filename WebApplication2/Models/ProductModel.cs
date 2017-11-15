using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public Nullable<double> ProductPrice { get; set; }
        public Nullable<int> ProductQuantity { get; set; }
    }
}