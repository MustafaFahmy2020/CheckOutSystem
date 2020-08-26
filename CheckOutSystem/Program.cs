using CheckOutSystem.Business;
using CheckOutSystem.JsonReader.Interface;
using CheckOutSystem.JsonReader.Service;
using CheckOutSystem.Service.Business;
using CheckOutSystem.Service.Interface;
using CheckOutSystem.Service.Models;
using CheckOutSystem.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CheckOutSystem
{
    public class Program
    {
        private static ICheckoutService _checkout;
        private static ILogger _logger;
        static void Main(string[] args)
        {
            try
            {

                SetUpDI();
                List<string> items = new List<string>();
                Console.WriteLine("Please Insert your item");
                while (true)
                {
                    items.Add(Console.ReadLine());
                    Console.WriteLine("Do you want to add more items yes/no");
                    if (Console.ReadLine() == "no")
                    {
                        break;
                    }
                    Console.WriteLine("Please Insert your item");
                }

                ResultObject resultObject = _checkout.GetTotalCount(items);
                if (resultObject != null)
                {
                    Console.WriteLine("Total Count = $" + resultObject.TotalCount);
                }
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                Console.ReadLine();
            }


        }
        public static void Checkout(List<string> items)
        {
            try
            {
                SetUpDIForUnitTesting();
                ResultObject resultObject = _checkout.GetTotalCount(items);
                Console.WriteLine(resultObject.TotalCount);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }
        public static void SetUpDIForUnitTesting()
        {

            try
            {
                var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<IDiscountService, DiscountService>()
                .AddSingleton<IOfferService, OfferService>()
                .AddSingleton<ICheckoutService, CheckOutService>()
                 .AddSingleton<IJsonService, JsonService>()
                .BuildServiceProvider();
                //configure console logging
                serviceProvider.GetService<ILoggerFactory>()
                .AddDebug();
                _logger = serviceProvider.GetService<ILoggerFactory>()
                   .CreateLogger<Program>();
                _checkout = serviceProvider.GetService<ICheckoutService>();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

        }
        public static void SetUpDI()
        {

            try
            {
                var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<IDiscountService, DiscountService>()
                .AddSingleton<IOfferService, OfferService>()
                .AddSingleton<ICheckoutService, CheckOutService>()
                 .AddSingleton<IJsonService, JsonService>()
                .BuildServiceProvider();
                //configure console logging
                serviceProvider.GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug)
                .AddDebug();
                _logger = serviceProvider.GetService<ILoggerFactory>()
                   .CreateLogger<Program>();
                _checkout = serviceProvider.GetService<ICheckoutService>();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

        }
    }
}
