using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutSystem.JsonReader.Model
{
    public class Discounts
    {
        public int NumberOfItems { get; set; }
        public double DiscountPrice { get; set; }
        public string SKU { get; set; }
    }
}
