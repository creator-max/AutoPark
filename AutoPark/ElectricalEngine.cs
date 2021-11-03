namespace AutoPark
{
    public class ElectricalEngine : Engine
    {
        public ElectricalEngine(double electricityConsumption)
            : base("Electrical", 0.1d)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public double ElectricityConsumption { get; }

        public double GetMaxKilometers(double batterySize)
            => batterySize / ElectricityConsumption;
    }
}
