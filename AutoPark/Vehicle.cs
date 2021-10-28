using System;

namespace AutoPark
{
    public class Vehicle : IComparable<Vehicle>
    {
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

        public double GetCalcTaxPerMonth() => Weight * 0.0013 +
            VehicleType.TaxCoefficient * 30 + 5;

        public override string ToString() => $"{Model}, {YearOfIssue}, " +
            $"{Weight}, {TankVolume}, {LicensePlat}, {Mileage}, " +
            $"{Color}, {GetCalcTaxPerMonth().ToString("0.00")}";

        public int CompareTo(Vehicle other)
        {
            if (other != null)
                return this.GetCalcTaxPerMonth().CompareTo(other.GetCalcTaxPerMonth());
            else
                throw new ArgumentNullException(nameof(other));
        }
    }
}
