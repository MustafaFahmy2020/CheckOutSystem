using CheckOutSystem.JsonReader.Model;
using CheckOutSystem.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutSystem.Service.Interface
{
    public interface IDiscountService
    {
        List<Discounts> GetAllDiscountsList();
        double GetTotalDiscount(ProductItems item);
        bool IsExistInDiscountList(ProductItems item);
    }
}
