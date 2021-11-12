using System;
using System.IO;
using AutoPark.CarWash;

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
            var washQueue = new MyQueue<Vehicle>(vehicles.Count);

            foreach(var vehicle in vehicles)
            {
                washQueue.Enqueue(vehicle);
                Console.WriteLine($"{vehicle.Model} ({vehicle.LicensePlat}) arrived at the wash.");
            }

            Console.WriteLine();
            while(washQueue.Count > 0)
            {
                var vehicle = washQueue.Dequeue();
                Console.WriteLine($"{vehicle.Model} ({vehicle.LicensePlat}) was washed.");
            }
        }
    }
}
