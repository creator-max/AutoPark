namespace AutoPark
{
    class Program
    {
        static void Main()
        {
            const string path = @"C:\Users\ASUS\source\repos\AutoPark\AutoPark\Data\";
            var collections = new Collections(
                    $"{path}types.csv", 
                    $"{path}vehicles.csv", 
                    $"{path}rents.csv");

            //1 task
            collections.Print();

            //2 task
            var vehicle = new Vehicle(1, collections.ListVehicleType[0], new GasolineEngine(2d, 8.1d), "Volkswagen Crafter", "5427 AX-7", 2022d, 2015, 376000d, Color.Blue, 500d);
            collections.Insert(collections.ListVehicle.Count - 1, vehicle);

            //3 task
            collections.Delete(1);
            collections.Delete(4);

            //4 task
            collections.Print();

            //5 task
            collections.Sort(new VehicleComparer());

            //6 task
            collections.Print();
        }
    }
}
