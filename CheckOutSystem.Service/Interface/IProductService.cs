using CheckOutSystem.JsonReader.Model;
using CheckOutSystem.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutSystem.Service.Interface
{
    public interface IProductService
    {
         double GetNormalCount(List<Products> products, ProductItems item);
        List<Products> GetAllProducts();
    }
}
