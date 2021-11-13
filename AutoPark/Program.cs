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
            string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Data\"));
            var collections = new Collections(
                    $"{path}types.csv",
                    $"{path}vehicles.csv",
                    $"{path}rents.csv");

            var vehicles = collections.Vehicles;
            var garageStack = new MyStack<Vehicle>(vehicles.Count);

            foreach(var vehicle in vehicles)
            {
                garageStack.Push(vehicle);
                Console.WriteLine($"{vehicle.Model} ({vehicle.LicensePlat}) arrived at the garage.");
            }

            Console.WriteLine();
            while(garageStack.Count > 0)
            {
                var vehicle = garageStack.Pop();
                Console.WriteLine($"{vehicle.Model} ({vehicle.LicensePlat}) drove out from the garage.");
            }
        }
    }
}
