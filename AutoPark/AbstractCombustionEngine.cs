namespace AutoPark
{
    public abstract class AbstractCombustionEngine : AbstractEngine
    {
        private const double CoefficientFuelConsumption = 100d;
        public AbstractCombustionEngine(string typeName, double taxCoefficient)
            : base(typeName, taxCoefficient)
        {

        }
        public double EngineCompacityInCubCM { get; protected set; }
        public double FuelConsumptionPer100 { get; protected set; }

        public override double GetMaxKilometers(double fuelTankCapacity)
            => fuelTankCapacity / FuelConsumptionPer100 * CoefficientFuelConsumption;
    }
}
