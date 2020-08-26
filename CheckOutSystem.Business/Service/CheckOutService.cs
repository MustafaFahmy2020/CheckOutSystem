using CheckOutSystem.Business;
using CheckOutSystem.JsonReader.Model;
using CheckOutSystem.Service.Interface;
using CheckOutSystem.Service.Models;
using CheckOutSystem.Service.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckOutSystem.Service.Business
{
    public class CheckOutService : ICheckoutService
    {
        #region Vars
        private readonly IDiscountService _discountService;
        private readonly IOfferService _offerService;
        private readonly IProductService _productService;
        private readonly List<Products> products;
        private readonly ILogger<CheckOutService> _logger;
        #endregion
        public CheckOutService(IDiscountService discountService, IOfferService offerService, IProductService productService, ILoggerFactory loggerFactory)
        {
            _discountService = discountService;
            _offerService = offerService;
            _productService = productService;
            products = _productService.GetAllProducts();
            _logger = loggerFactory.CreateLogger<CheckOutService>();
        }
        /// <summary>
        /// Get Total Counts and Free Items
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public ResultObject GetTotalCount(List<string> items)
        {
            List<ProductItems> productItemList = null;
            ResultObject ResultObject = null;
            try
            {
                if (items != null && items.Any())
                {
                    if (products != null)
                    {
                        productItemList = GroupItems(items);
                        ResultObject = new ResultObject();
                        foreach (var item in productItemList)
                        {
                            if (_discountService.IsExistInDiscountList(item))
                            {
                                ResultObject.TotalCount += _discountService.GetTotalDiscount(item);
                            }
                            else if (_offerService.IsGift(item))
                            {
                                ResultObject.TotalCount += _offerService.CheckfreeItems(products, productItemList, item);
                            }
                            else
                            {
                                ResultObject.TotalCount += _productService.GetNormalCount(products, item);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return ResultObject;
        }
        /// <summary>
        /// Get Custom Product Items
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private List<ProductItems> GroupItems(List<string> items)
        {
            List<ProductItems> productItemList = new List<ProductItems>();
            try
            {
                foreach (string item in items)
                {
                    if (products.Any(x => x.SKU == item))
                    {
                        ProductItems productItems = productItemList.Where(x => x.SKU == item).FirstOrDefault();
                        if (productItems == null)
                        {
                            ProductItems newProductItems = new ProductItems() { SKU = item, Count = 1 };
                            productItemList.Add(newProductItems);
                        }
                        else
                        {
                            productItems.Count++;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return productItemList;
        }
    }
}
