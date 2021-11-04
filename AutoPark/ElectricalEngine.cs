namespace AutoPark
{
    public class ElectricalEngine : AbstractEngine
    {
        public ElectricalEngine(double electricityConsumption)
            : base("Electrical", 0.1d)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public double ElectricityConsumption { get; }

        public override double GetMaxKilometers(double batterySize)
            => batterySize / ElectricityConsumption;
    }
}
