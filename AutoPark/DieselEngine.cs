﻿namespace AutoPark
{
    public class DieselEngine : CombustionEngine
    {
        public DieselEngine(double engineCompacityInCubCM, double fuelConsumptionPer100)
            : base("Diesel", 1.2)
        {
            EngineCompacityInCubCM = engineCompacityInCubCM;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }
    }
}
