namespace AutoPark
{
    public abstract class AbstractEngine
    {
        public AbstractEngine(string typeName, double taxCoefficient)
        {
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        public string TypeName { get; }
        public double TaxCoefficient { get; }

        public abstract double GetMaxKilometers(double fuelTank);
    }
}
