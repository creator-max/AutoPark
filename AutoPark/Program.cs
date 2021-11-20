using System;
using System.IO;
using AutoPark.CarWash;
using AutoPark.Garage;

namespace AutoPark
{
    class Program
    {
        static void Main()
        {
            string path = $@"{Directory.GetCurrentDirectory()}\Data\";
            var collections = new Collections(
                    $"{path}types.csv",
                    $"{path}vehicles.csv",
                    $"{path}rents.csv");

            var vehicles = collections.Vehicles;

            var garage = new MyStack<Vehicle>(vehicles.Count);

            foreach (var vehicle in vehicles)
            {
                garage.Push(vehicle);
                Console.WriteLine($"{vehicle.Model} ({vehicle.LicensePlat}) arrived at the garage.");
            }

            Console.WriteLine();
            while (garage.Count > 0)
            {
                var vehicle = garage.Pop();
                Console.WriteLine($"{vehicle.Model} ({vehicle.LicensePlat}) left the garage.");
            }
        }
    }
}
