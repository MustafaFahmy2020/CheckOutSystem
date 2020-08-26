using CheckOutSystem.JsonReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutSystem.JsonReader.Interface
{
    public interface IJsonService
    {
        List<Products> GetProducts();
        List<Offers> GetOffers();
        List<Discounts> GetDiscounts();

    }
}
