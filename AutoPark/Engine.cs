namespace AutoPark
{
    public class Engine
    {
        public Engine(string typeName, double taxCoefficient)
        {
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        public string TypeName { get; }
        public double TaxCoefficient { get; }
    }
}
