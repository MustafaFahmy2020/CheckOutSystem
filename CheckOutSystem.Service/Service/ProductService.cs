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
    public class ProductService : IProductService
    {
        #region Vars
        private List<Products> products;
        private readonly IJsonService _jsonService;
        private readonly ILogger<ProductService> _logger;
        #endregion
        public ProductService(ILoggerFactory loggerFactory, IJsonService jsonService)
        {
            _jsonService = jsonService;
            _logger = loggerFactory.CreateLogger<ProductService>();

        }
        /// <summary>
        /// Get All Json Files
        /// </summary>
        /// <returns></returns>
        public List<Products> GetAllProducts()
        {

            try
            {
                products = _jsonService.GetProducts();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return products;
        }
        /// <summary>
        /// Normal Calculation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public double GetNormalCount(List<Products> products, ProductItems item)
        {
            double totalCounts = default(double);
            try
            {
                double price = products.Where(x => x.SKU == item.SKU).FirstOrDefault().Price;
                totalCounts = (price * item.Count);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return totalCounts;
        }
    }
}
