using System;

namespace AutoPark
{
    public class VehicleType
    {
        public VehicleType() { }

        public VehicleType(int id,
                string typeName,
                double taxCoefficient)
        {
            Id = id;
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        public int Id { get; }
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }

        public override string ToString() => $"{TypeName}; {TaxCoefficient}";
        public void Display()
        {
            Console.WriteLine($"typeName = {TypeName} - taxCoefficient = {TaxCoefficient}");
        }
    }
}
