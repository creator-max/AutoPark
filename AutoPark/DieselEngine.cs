namespace AutoPark
{
    public class DieselEngine : AbstractCombustionEngine
    {
        public DieselEngine(double engineCompacityInCubCM, double fuelConsumptionPer100)
            : base("Diesel", 1.2d)
        {
            EngineCompacityInCubCM = engineCompacityInCubCM;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }
    }
}
