using CheckOutSystem.JsonReader.Interface;
using CheckOutSystem.JsonReader.Model;
using CheckOutSystem.JsonReader.Service;
using CheckOutSystem.Service.Interface;
using CheckOutSystem.Service.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckOutSystem.Service.Service
{
    public class DiscountService : IDiscountService
    {

        public List<Discounts> discounts;
        private readonly ILogger<DiscountService> _logger;
        private readonly IJsonService _jsonService;
        public DiscountService(IJsonService jsonService, ILoggerFactory loggerFactory)
        {
            _jsonService = jsonService;
            LoadDiscounts();
            _logger = loggerFactory.CreateLogger<DiscountService>();

        }
        private void LoadDiscounts()
        {

            try
            {
                discounts = _jsonService.GetDiscounts();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

        }
        /// <summary>
        /// Get all discounts list
        /// </summary>
        /// <returns></returns>
        public List<Discounts> GetAllDiscountsList()
        {
            return discounts;
        }
        /// <summary>
        /// If item exists in Discount List
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsExistInDiscountList(ProductItems item)
        {
            bool isExist = default(bool);
            try
            {

                isExist = discounts.Any(x => x.SKU == item.SKU && x.NumberOfItems < item.Count);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return isExist;
        }
        /// <summary>
        /// Calculate Discounts
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public double GetTotalDiscount(ProductItems item)
        {
            double totalCount = default(double);
            try
            {
                double discount = discounts.Where(x => x.SKU == item.SKU).FirstOrDefault().DiscountPrice;
                totalCount = discount * item.Count;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return totalCount;
        }


    }
}
