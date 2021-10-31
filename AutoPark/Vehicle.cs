using System;

namespace AutoPark
{
    public class Vehicle : IComparable<Vehicle>
    {
        private const double WeightCoefficient = 0.0013d;
        private const double TaxCoefficient = 30d;
        private const double TaxPerMonthAddition = 5d;

        public Vehicle() { }

        public Vehicle(VehicleType vehicleType,
                string model,
                string licensePlat,
                double weight,
                ushort yearOfIssue,
                double mileage,
                Color color,
                double tankVolume)
        {
            VehicleType = vehicleType;
            Model = model;
            LicensePlat = licensePlat;
            Weight = weight;
            YearOfIssue = yearOfIssue;
            Mileage = mileage;
            Color = color;
            TankVolume = tankVolume;
        }

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
    }
}
