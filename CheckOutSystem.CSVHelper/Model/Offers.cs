using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutSystem.JsonReader.Model
{
    public class Offers
    {
        public int NumberOfItems { get; set; }
        public int NumberOfFreeItems { get; set; }
        public string ItemSKU { get; set; }
        public string SKU { get; set; }
    }
}
