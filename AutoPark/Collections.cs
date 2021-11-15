using System;
using System.Collections.Generic;
using System.IO;
using AutoPark.CsvHelper;

namespace AutoPark
{
    public class Collections
    {
        public Collections(string typesPath, string vehiclesPath, string rentsPath)
        {
            VehicleTypes = ParseTypes(typesPath);
            Vehicles = ParseVehicles(vehiclesPath);
            LoadRents(rentsPath);
        }

        public List<VehicleType> VehicleTypes { get; }
        public List<Vehicle> Vehicles { get; }        

        public void Insert(int index, Vehicle vehicle)
        {
            if (index >= 0 && index < Vehicles.Count)
            {
                Vehicles.Insert(index, vehicle);
            }
            else
            {
                Vehicles.Add(vehicle);
            }
        }

        public int Delete(int index)
        {
            if (index < 0 || index >= Vehicles.Count)
            {
                return -1;
            }
            Vehicles.RemoveAt(index);
            return index;
        }

        public double SumTotalProfit()
        {
            var profit = 0d;
            foreach(var vehicle in Vehicles)
            {
                profit += vehicle.GetTotalProfit();
            }
            return profit;
        }

        public void Sort(IComparer<Vehicle> comparator)
        {
            Vehicles.Sort(comparator);
        }

        public void Print()
        {
            Console.WriteLine(
                $"{"ID",-5}{"Type",-10}{"Model name",-25}" +
                $"{"Number",-15}{"Weight(kg)",-15}{"Year",-10}" +
                $"{"Mileage",-10}{"Color",-10}{"Income",-10}" +
                $"{"Tax",-10}{"Profit",-10}");


            foreach (var vehicle in Vehicles)
            {
                Console.WriteLine(
                    $"{vehicle.Id,-5}" +
                    $"{vehicle.VehicleType.TypeName,-10}" +
                    $"{vehicle.Model,-25}" +
                    $"{vehicle.LicensePlat,-15}" +
                    $"{vehicle.Weight,-15}" +
                    $"{vehicle.YearOfIssue,-10}" +
                    $"{vehicle.Mileage,-10}" +
                    $"{vehicle.Color,-10}" +
                    $"{vehicle.GetTotalIncome(),-10:0.00}" +
                    $"{vehicle.GetCalcTaxPerMonth(),-10:0.00}" +
                    $"{vehicle.GetTotalProfit(),-10:0.00}");
            }
            Console.WriteLine($"Total profit: {SumTotalProfit():f}\n");
        }

        #region Parsing .csv to VehicleType list
        private VehicleType CreateVehicleType(List<string> fields)
        {
            //parsing info from csvData to VehicleType(...)
            var id = int.Parse(fields[0]);
            var typeName = fields[1];
            var taxCoefficient = double.Parse(fields[2]);

            //creating new VehicleType
            var vehicleType = new VehicleType(id, typeName, taxCoefficient);
            return vehicleType;
        }

        private List<VehicleType> ParseTypes(string typesCsvPath)
        {
            try
            {
                //reading data from .csv
                var csv = new CsvReader(typesCsvPath);
                List<List<string>> csvData = csv.Read();

                var listVehicleType = new List<VehicleType>();
                foreach(var fields in csvData)
                {
                    listVehicleType.Add(CreateVehicleType(fields));
                }
                
                return listVehicleType;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {typesCsvPath} not found.");
                return new List<VehicleType>();
            }
        }
        #endregion

        #region Parsing .csv to Vehicle list
        public Vehicle CreateVehicle(List<string> fields)
        {
            //parsing info from csvData to Vehicle(...)
            var id = int.Parse(fields[0]);

            var vehicleTypeId = int.Parse(fields[1]);
            var vehicleType = VehicleTypes[vehicleTypeId];

            var model = fields[2];
            var licensePlat = fields[3];
            var weight = double.Parse(fields[4]);
            var year = ushort.Parse(fields[5]);
            var mileage = double.Parse(fields[6]);
            var color = (Color)Enum.Parse(typeof(Color), fields[7]);

            AbstractEngine engine = fields[8] switch
            {
                "Electrical" => new ElectricalEngine(double.Parse(fields[10])),
                "Gasoline" => new GasolineEngine(double.Parse(fields[9]), double.Parse(fields[10])),
                "Diesel" => new DieselEngine(double.Parse(fields[9]), double.Parse(fields[10])),
                _ => null
            };

            double tankCapacity = double.Parse(fields[11]);


            //creating a new Vehicle
            var vehicle = new Vehicle(id, vehicleType, engine, model, licensePlat, weight, year, mileage, color, tankCapacity);
            return vehicle;
        }

        private List<Vehicle> ParseVehicles(string vehiclesCsvPath)
        {
            try
            {
                //reading data from .csv
                var csv = new CsvReader(vehiclesCsvPath);
                List<List<string>> csvData = csv.Read();

                var listVehicle = new List<Vehicle>();
                foreach (var fields in csvData)
                {
                    
                    listVehicle.Add(CreateVehicle(fields));
                }
                return listVehicle;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {vehiclesCsvPath} not found.");
                return new List<Vehicle>();
            }
        }
        #endregion

        #region Parsing .csv to Rents list
        private void LoadRents(string rentsCsvPath)
        {
            try
            {
                var csv = new CsvReader(rentsCsvPath);
                List<List<string>> csvData = csv.Read();

                foreach (var fields in csvData)
                {
                    var vehicleId = int.Parse(fields[0]);
                    var date = DateTime.Parse(fields[1]);
                    var cost = double.Parse(fields[2]);

                    foreach (var vehicle in Vehicles)
                    {
                        if (vehicle.Id == vehicleId)
                        {
                            vehicle.ListRent ??= new List<Rent>();
                            vehicle.ListRent.Add(new Rent(date, cost));
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {rentsCsvPath} not found.");
            }
            
        }
        #endregion
    }
}
