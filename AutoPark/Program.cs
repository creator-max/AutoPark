using System;

namespace AutoPark
{
    class Program
    {
        static void Main()
        {
            //1 task
            var vehicleTypes = new VehicleType[]
            {
                new VehicleType("Bus", 1.2d),
                new VehicleType("Car", 1d),
                new VehicleType("Rink", 1.5d),
                new VehicleType("Tractor", 1.2d)
            };

            //2 task
            var vehicles = new Vehicle[]
            {
                new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "5427 AX-7", 2022d, 2015, 376000d, Color.Blue, 500d),
                new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "6427 AA-7", 2500d, 2014, 227010d, Color.White, 500d),
                new Vehicle(vehicleTypes[0], "Electric Bus E321", "6785 BA-7", 12080d, 2019, 20451, Color.Green, 500d),
                new Vehicle(vehicleTypes[1], "Golf 5", "8682 AX-7", 1200d, 2006, 230451d, Color.Gray, 500d),
                new Vehicle(vehicleTypes[1], "Tesla Model S 70D", "E001 AA-7", 2200d, 2019, 10454d, Color.White, 500d),
                new Vehicle(vehicleTypes[2], "Hamm HD 12 VV", null, 3000d, 2016, 122d, Color.Yellow, 500d),
                new Vehicle(vehicleTypes[3], "МТЗ Беларус-1025.4", "1145 AB-7", 1200d, 2020, 109d, Color.Red, 500d)
            };

            //3 task
            VehicleHelper.PrintVehicles(vehicles);

            //4 task
            Console.WriteLine("\nSorting array...\n");
            Array.Sort(vehicles);

            //5 task
            VehicleHelper.PrintVehicles(vehicles);

            //6 task
            Console.WriteLine($"\nVehicle with min mileage: {VehicleHelper.GetVehicleWithMinMileage(vehicles)}" +
                $"\nVehicle with max mileage: {VehicleHelper.GetVehicleWithMaxMileage(vehicles)}");
        }
    }
}
