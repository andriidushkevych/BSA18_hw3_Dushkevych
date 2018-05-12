using System;

namespace ParkingLib
{
    public enum CarType { Passenger, Truck, Bus, Motorcycle }

    public class Car
    {
        private static int idCounter = 1;

        public int Id { get; private set; }
        public double Balance { get; private set; }
        public CarType CarType { get; private set; }

        public Car(CarType carTypeArg, double initialBalance)
        {
            Id = idCounter;
            Balance = initialBalance;
            CarType = carTypeArg;
            idCounter++;
        }

        public void LoadCarBalance(double amount)
        {
            Balance += amount;
        }

        public Transaction ChargeCarParkingFee()
        {
            double amountToCharge = (double)Settings.ParkingPrice[CarType];
            if (amountToCharge > Balance)
            {
                amountToCharge *= Settings.Fine;
            }
            Balance -= amountToCharge;
            return new Transaction(Id, amountToCharge);
        }
    }
}
