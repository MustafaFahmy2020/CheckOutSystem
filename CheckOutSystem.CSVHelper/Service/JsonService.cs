using CheckOutSystem.JsonReader.Interface;
using CheckOutSystem.JsonReader.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CheckOutSystem.JsonReader.Service
{
    public class JsonService : IJsonService
    {
        private readonly ILogger<JsonService> _logger;
        public JsonService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<JsonService>();

        }
        public List<Products> GetProducts()
        {
            List<Products> productList = null;
            try
            {
                using (StreamReader r = new StreamReader("Products.json"))
                {
                    string json = r.ReadToEnd();
                    productList = JsonConvert.DeserializeObject<List<Products>>(json);
                }
            }
            catch (Exception ex)
            {


                _logger.LogError(ex.Message);
            }
            return productList;
        }
        public List<Offers> GetOffers()
        {
            List<Offers> offerList = null;
            try
            {
                using (StreamReader r = new StreamReader("Offers.json"))
                {
                    string json = r.ReadToEnd();
                    offerList = JsonConvert.DeserializeObject<List<Offers>>(json);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return offerList;
        }
        public List<Discounts> GetDiscounts()
        {
            List<Discounts> dicountList = null;
            try
            {
                using (StreamReader r = new StreamReader("Discounts.json"))
                {
                    string json = r.ReadToEnd();
                    dicountList = JsonConvert.DeserializeObject<List<Discounts>>(json);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return dicountList;
        }
    }
}
