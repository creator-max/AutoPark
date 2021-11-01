namespace AutoPark
{
    public class GasolineEngine : CombustionEngine
    {
        public GasolineEngine(double engineCompacityInCubCM, double fuelConsumptionPer100)
            : base("Gasoline", 1)
        {
            EngineCompacityInCubCM = engineCompacityInCubCM;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }
    }
}
