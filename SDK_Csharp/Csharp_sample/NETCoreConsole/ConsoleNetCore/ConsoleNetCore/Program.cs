﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using IO.Deliveree.Api;
using IO.Deliveree.Client;
using IO.Deliveree.Model;
using Newtonsoft.Json;

namespace ConsoleNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration.Default.ApiKey.Add("Authorization", "ZrfYRQAzqMS9BH8QQhxa");
            //DeliveryGetQuotes();
            //AddDelivery();
            CancelBooking(17246);
        }

        /// <summary>
        /// Add deliveree booking with full status code return
        /// </summary>
        public static void AddDelivery()
        {
            var apiInstance = new DelivereeApi();
            Delivery body = new Delivery
            {
                VehicleTypeId = 62,
                JobOrderNumber = "6666",
                TimeType = "schedule",
                PickupTime = DateTime.Parse("2016-05-13T09:51:16+07:00"),
                Note = "Fine - Fragile item that needs good care",
                Locations = new List<Location>
                {
                    new Location
                    {
                        Address = "TMA testing. Sultan Iskandar Muda No.21, Arteri Pondok Indah",
                        Latitude = (double)-6.2608232,
                        Longitude = (double)106.7884168,
                        RecipientName = "Justin",
                        RecipientPhone = "+84903398399",
                        Note = "Second floor, room 609"
                    },
                    new Location
                    {
                        Address = "TMA testing Gedung Inti Sentra, Jl. Taman Kemang, RT.14/RW.1",
                        Latitude = (double)-6.2608232,
                        Longitude = (double)106.7884168,
                        RecipientName = "Tong",
                        RecipientPhone = "+84903398399",
                        Note = "Second floor, room 609",
                        NeedCod = true,
                        NeedPod = true,
                        CodInvoiceFees = 5000,
                        PodNote = "You need to do ..."
                    }
                }
            };

            try
            {
                ApiResponse<Object> result = apiInstance.DeliveriesPostWithHttpInfo(body);
                Console.WriteLine(result.StatusCode);
            }
            catch (Exception e)
            {
                Debug.Print("Exception: " + e.Message);
            }

            Console.ReadKey();

        }

        /// <summary>
        /// DeliveriesGetQuotes 
        /// </summary>
        public static void DeliveryGetQuotes()
        {
            var apiInstance = new DelivereeApi();
            var body = new Quote
            {
                TimeType = "now",
                Locations = new List<Location>
                {
                    new Location
                    {
                        Address = "Jl. Sultan Iskandar Muda No.21, Arteri Pondok Indah, Pd. Pinang, Kby. Lama, Kota Jakarta Selatan, Daerah Khusus Ibukota Jakarta, Indonesia",
                        Latitude = (double)-6.2608232,
                        Longitude = (double)106.7884168
                    }
                }
            };

            try
            {
                ApiResponse<object> result = apiInstance.DeliveriesGetQuotePostWithHttpInfo(body);
                Console.WriteLine(result.Data.ToString());
            }
            catch (Exception e)
            {
                Debug.Print("Exception: " + e.Message);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// CancelBooking
        /// </summary>
        /// <param name="id"></param>
        public static void CancelBooking(int id)

        {
            var apiInstance = new DelivereeApi();
            try
            {
                ApiResponse<Object> obj = apiInstance.CancelBookingWithHttpInfo(id);
                Console.Write(obj.StatusCode);

            }
            catch (Exception e)
            {
                Console.Write("Exception: " + e.Message);
            }
            
            Console.ReadKey();

        }
    }
}
