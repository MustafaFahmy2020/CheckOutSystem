using CheckOutSystem.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutSystem.Business
{
    public interface ICheckoutService
    {
        ResultObject GetTotalCount(List<string> items);
    }
}
