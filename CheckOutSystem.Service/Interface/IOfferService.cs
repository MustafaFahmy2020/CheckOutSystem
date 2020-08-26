using CheckOutSystem.JsonReader.Model;
using CheckOutSystem.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutSystem.Service.Interface
{
    public interface IOfferService
    {
        bool IsGift(ProductItems item);
        double CheckfreeItems(List<Products> products, List<ProductItems> itemList, ProductItems item);

    }
}
