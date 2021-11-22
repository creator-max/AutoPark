using AutoPark.CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutoPark.CarRepair
{
    public class Orders
    {
        private List<string> _details;

        public Orders(string ordersPath)
        {
            _details = new List<string>();
            OrdersCount = new Dictionary<string, int>();
            LoadOrders(ordersPath);
        }

        public Dictionary<string, int> OrdersCount { get; private set; }

        public void Print()
        {
            foreach(var (key, value) in OrdersCount)
            {
                Console.WriteLine($"{key, -7}:{value, 3}шт.");
            }
        }

        public void AddOrder(string detail)
        {
            if (OrdersCount.ContainsKey(detail))
            {
                OrdersCount[detail]++;
            }
            else
            {
                OrdersCount.Add(detail, 1);
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
