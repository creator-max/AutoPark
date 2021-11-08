using System;
using System.Collections.Generic;

namespace AutoPark
{
    public class Vehicle : IComparable<Vehicle>
    {
        private const double WeightCoefficient = 0.0013d;
        private const double TaxCoefficient = 30d;
        private const double TaxPerMonthAddition = 5d;

        public Vehicle() { }

        public Vehicle(int id,
                VehicleType vehicleType,
                AbstractEngine engine,
                string model,
                string licensePlat,
                double weight,
                ushort yearOfIssue,
                double mileage,
                Color color,
                double tankVolume)
        {
            Id = id;
            Engine = engine;
            VehicleType = vehicleType;
            Model = model;
            LicensePlat = licensePlat;
            Weight = weight;
            YearOfIssue = yearOfIssue;
            Mileage = mileage;
            Color = color;
            TankVolume = tankVolume;
            ListRent = new List<Rent>();
        }

        public int Id { get; }
        public List<Rent> ListRent { get; set; }
        public AbstractEngine Engine { get; }
        public VehicleType VehicleType { get; }
        public string Model { get; }
        public ushort YearOfIssue { get; }
        public double Weight { get; }
        public double TankVolume { get; }
        public string LicensePlat { get; set; }
        public double Mileage { get; set; }
        public Color Color { get; set; }

        public double GetCalcTaxPerMonth() => Weight * WeightCoefficient +
            VehicleType.TaxCoefficient * TaxCoefficient + TaxPerMonthAddition;

        public double GetTotalIncome()
        {
            var sum = 0d;
            foreach(var rent in ListRent)
            {
                sum += rent.Price;
            }
            return sum;
        }

        public double GetTotalProfit() => GetTotalIncome() - GetCalcTaxPerMonth();

        public override string ToString() => $"{Model}, {YearOfIssue}, " +
            $"{Weight}, {TankVolume}, {LicensePlat}, {Mileage}, " +
            $"{Color}, {GetCalcTaxPerMonth().ToString("0.00")}";

        public int CompareTo(Vehicle other)
        {
            if (other != null)
                return GetCalcTaxPerMonth().CompareTo(other.GetCalcTaxPerMonth());
            else
                throw new ArgumentNullException(nameof(other));
        }

        public override bool Equals(object obj)
        {
            return obj is Vehicle other && VehicleType == other.VehicleType && Model == other.Model;
        }
    }
}
