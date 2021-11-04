using System;
using System.Collections.Generic;

namespace AutoPark
{
    public static class VehicleHelper
    {
        public static Vehicle GetVehicleWithMinMileage(IReadOnlyList<Vehicle> vehicles)
        {
            var minMileageVehicle = vehicles[0];
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Mileage < minMileageVehicle.Mileage)
                    minMileageVehicle = vehicle;
            }
            return minMileageVehicle;
        }

        public static Vehicle GetVehicleWithMaxMileage(IReadOnlyList<Vehicle> vehicles)
        {
            var maxMileageVehicle = vehicles[0];
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Mileage > maxMileageVehicle.Mileage)
                    maxMileageVehicle = vehicle;
            }
            return maxMileageVehicle;
        }

        public static Vehicle GetVehicleWithMaxKilometers(IReadOnlyList<Vehicle> vehicles)
        {
            var maxKilometersVehicle = vehicles[0];
            var maxKilometers = vehicles[0].Engine.GetMaxKilometers(vehicles[0].TankVolume);
            
            foreach(var vehicle in vehicles)
            {
                if (vehicle.Engine.GetMaxKilometers(vehicle.TankVolume) > maxKilometers)
                {
                    maxKilometersVehicle = vehicle;
                    maxKilometers = vehicle.Engine.GetMaxKilometers(vehicle.TankVolume);
                }
            }
            return maxKilometersVehicle;
        }

        public static void PrintVehicles(IReadOnlyList<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        public static void PrintEqualsVehicles(IReadOnlyList<Vehicle> vehicles)
        {
            for (int i = 0; i < vehicles.Count - 1; i++)
            {
                for (int j = i + 1; j < vehicles.Count; j++)
                {
                    if(vehicles[i].Equals(vehicles[j]))
                        Console.WriteLine($"\nEquals:\n{vehicles[i]}\n{vehicles[j]}");
                }
            }   
        }

    }
}
