using System;
using AutoPark.CarRepair;

namespace AutoPark
{
    class Program
    {
        static void Main()
        {
            string path = $@"{AppContext.BaseDirectory}\Data\";

            var orders = new Orders($"{path}orders.csv");
            orders.Print();
        }
    }
}
