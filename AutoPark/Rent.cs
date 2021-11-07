using System;

namespace AutoPark
{
    public class Rent
    {
        public Rent()
        {

        }

        public Rent(DateTime dateOfRent, double price)
        {
            DateOfRent = dateOfRent;
            Price = price;
        }

        public DateTime DateOfRent { get; }
        public double Price { get; }
    }
}
