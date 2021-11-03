namespace AutoPark
{
    public class CombustionEngine : Engine
    {
        private const double CoefficientFuelConsumption = 100d;
        public CombustionEngine(string typeName, double taxCoefficient)
            : base(typeName, taxCoefficient)
        {

        }
        public double EngineCompacityInCubCM { get; protected set; }
        public double FuelConsumptionPer100 { get; protected set; }

        public double GetMaxKilometers(double fuelTankCapacity)
            => fuelTankCapacity / FuelConsumptionPer100 * CoefficientFuelConsumption;
    }
}
