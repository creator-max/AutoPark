using AutoPark.CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutoPark.CarRepair
{
    public class OrderService
    {
        private List<string> _details;

        public OrderService(string ordersPath)
        {
            _details = new List<string>();
            Orders = new Dictionary<string, int>();
            LoadOrders(ordersPath);
        }

        public Dictionary<string, int> Orders { get; private set; }

        public void Print()
        {
            foreach(var (key, value) in Orders)
            {
                Console.WriteLine($"{key, -7}:{value, 3}шт.");
            }
        }

        private void AddOrder(string detail)
        {
            if (Orders.ContainsKey(detail))
            {
                Orders[detail]++;
            }
            else
            {
                Orders.Add(detail, 1);
            }
        }

        private void LoadOrders(string csvPath)
        {
            try
            {
                var csv = new CsvReader(csvPath);
                var csvData = csv.Read();

                foreach(var str in csvData)
                {
                    foreach(var item in str)
                    {
                        _details.Add(item);
                    }
                }

                foreach (var detail in _details)
                {
                    AddOrder(detail);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {csvPath} not found.");
            }
        }
    }
}
