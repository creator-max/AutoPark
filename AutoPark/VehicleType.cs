using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPark
{
    public class VehicleType
    {

        public VehicleType() { }

        public VehicleType(string typeName,
                double taxCoefficient)
        {
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }

        public override string ToString() => $"{TypeName}; {TaxCoefficient}";
        public void Display()
        {
            Console.WriteLine($"typeName = {TypeName} - taxCoefficient = {TaxCoefficient}");
        }
    }
}
