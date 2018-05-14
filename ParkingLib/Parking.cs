using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Linq;

namespace ParkingLib
{
    public sealed class Parking
    {
        private static readonly Parking parking = new Parking();
        
        public static Parking ParkingInstance { get { return parking; } }

        public List<Car> Cars { get; private set; }
        public List<Transaction> Transactions { get; private set; }
        public double Balance { get; private set; }

        private Parking()
        {
            Cars = new List<Car>();
            Transactions = new List<Transaction>();
            Balance = 0.0;
            Timer aTimer = new Timer(Settings.Timeout * 1000); //from https://msdn.microsoft.com/en-us/library/system.timers.timer(v=vs.110).aspx#Examples
            aTimer.Elapsed += ChargeParkingFee;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void ChargeParkingFee(Object source, ElapsedEventArgs e)
        {
            if (Cars.Count != 0)
            {
                foreach (Car car in Cars)
                {
                    Transaction newTran = car.ChargeCarParkingFee();
                    Transactions.Add(newTran);
                    Balance += newTran.ChargedAmount;
                }
            }
        }

        public void AddCar(Car newCar)
        {
            Cars.Add(newCar);            
        }

        public void RemoveCar(int id)
        {
            Cars.Remove(Cars.FirstOrDefault(x => x.Id == id));
        }

        public void LoadCarBalance(int id, double amount)
        {
            Cars.FirstOrDefault(x => x.Id == id).LoadCarBalance(amount);
        }

        public List<Transaction> GetTransactionsHistory()
        {
            List<Transaction> result = new List<Transaction>();
            foreach (Transaction tran in Transactions)
            {
                result.Add(tran);
            }
            return result;
        }

        public List<Transaction> GetRecentTransactionHistory()
        {
            List<Transaction> result = new List<Transaction>();
            foreach (Transaction tran in Transactions)
            {
                TimeSpan diff = DateTime.Now.Subtract(tran.TransactionDateTime);
                if (diff.Minutes < 1)
                {
                    result.Add(tran);
                }
            }
            return result;
        }

        public int GetParkingEmptySpots()
        {
            return Settings.ParkingSpace - Cars.Count;
        }

        public List<Car> GetCarsList()
        {
            return Cars;
        }
    }
}
