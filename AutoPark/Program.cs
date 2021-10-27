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
            foreach (var vehicleType in vehicleTypes)
            {
                vehicleType.Display();
            }

            //3task
            vehicleTypes[^1].TaxCoefficient = 1.3d;

            //4task
            Console.WriteLine($"\nMax coefficient is {FindMaxTaxCoefficient(vehicleTypes)}");

            //5 task
            Console.WriteLine($"Average coefficient is {CalculateAverageTaxCoefficient(vehicleTypes)}\n");

            //6 task
            var sum = 0d;
            var maxCoefficient = 0d;
            foreach (var vehicleType in vehicleTypes)
            {
                vehicleType.Display();
                if (vehicleType.TaxCoefficient > maxCoefficient)
                {
                    maxCoefficient = vehicleType.TaxCoefficient;
                }
                sum += vehicleType.TaxCoefficient;
            }
            var average = sum / vehicleTypes.Length;

            Console.WriteLine($"\nMax coefficient is {FindMaxTaxCoefficient(vehicleTypes)}" +
                    $"Average coefficient is {CalculateAverageTaxCoefficient(vehicleTypes)}\n");

            //7 task
            foreach (var vehicleType in vehicleTypes)
            {
                Console.WriteLine(vehicleType);
            }
        }

        public static double FindMaxTaxCoefficient(VehicleType[] vehicleTypes)
        {
            var maxCoefficient = 0d;
            foreach (var item in vehicleTypes)
            {
                if (item.TaxCoefficient > maxCoefficient)
                {
                    maxCoefficient = item.TaxCoefficient;
                }
            }
            return maxCoefficient;
        }

        public static double CalculateAverageTaxCoefficient(VehicleType[] vehicleTypes)
        {
            var sum = 0d;
            foreach (var vehicleType in vehicleTypes)
            {
                sum += vehicleType.TaxCoefficient;
            }
            return sum / vehicleTypes.Length;
        }
    }
}
