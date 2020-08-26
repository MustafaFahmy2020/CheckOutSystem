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
    public class OfferService : IOfferService
    {
        private List<Offers> offers;
        private readonly ILogger<OfferService> _logger;
        private readonly IJsonService _jsonService;
        public OfferService(Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, IJsonService jsonService)
        {
            _jsonService = jsonService;
            LoadOffers();
            _logger = loggerFactory.CreateLogger<OfferService>();
        }
        private void LoadOffers()
        {
            try
            {
                offers = _jsonService.GetOffers();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }

        /// <summary>
        /// Check free item prices
        /// </summary>
        /// <param name="itemList"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public double CheckfreeItems(List<Products> products, List<ProductItems> itemList, ProductItems item)
        {
            double totalCounts = default(double);

            try
            {
                double price = products.Where(x => x.SKU == item.SKU).FirstOrDefault().Price;
                Offers offer = offers.Where(x => x.ItemSKU == item.SKU).FirstOrDefault();
                ProductItems productItems = itemList.Where(x => x.SKU == offer.SKU).FirstOrDefault();
                if (productItems != null)
                {

                    if (productItems.Count >= offer.NumberOfItems)
                    {
                        if ((productItems.Count - offer.NumberOfItems) >= offer.NumberOfItems)
                        {
                            if (item.Count > ((productItems.Count * offer.NumberOfFreeItems) / offer.NumberOfItems))
                            {

                                totalCounts = (item.Count - ((productItems.Count * offer.NumberOfFreeItems) / offer.NumberOfItems)) * price;
                            }
                        }
                        else if (offer.NumberOfFreeItems <= item.Count)
                        {
                            totalCounts = (item.Count - offer.NumberOfFreeItems) * price;
                        }

                    }
                    else
                    {
                        totalCounts = price * item.Count;
                    }


                }
                else
                {
                    totalCounts = price * item.Count;
                }


            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return totalCounts;
        }
        /// <summary>
        /// check if this item is a gift already
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsGift(ProductItems item)
        {
            bool isGift = default(bool);
            try
            {
                isGift = offers.Any(x => x.ItemSKU == item.SKU);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return isGift;
        }
    }
}
