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
           // aTimer.Elapsed += ChargeParkingFee;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        //private void ChargeParkingFee(Object source, ElapsedEventArgs e)
        //{
        //    if (Cars.Count != 0)
        //    {
        //        foreach (Car car in Cars)
        //        {
        //            Transaction newTran = car.ChargeCarParkingFee();
        //            Transactions.Add(newTran);
        //            Balance += newTran.ChargedAmount;
        //        }
        //    }
        //}

        //public void AddCar()
        //{
        //    if (Cars.Count >= Settings.ParkingSpace)
        //    {
        //        //Console.WriteLine("Parking lot is full, please wait for available spot!");
        //    }
        //    else
        //    {
        //        Car newCar = new Car((CarType)(carTypeChoice - 1), balance);
        //        Cars.Add(newCar);
        //    }
        //}

        //public  GetCarDetailsById(int carId)
        //{
        //    return Cars.Where<Car>((carId) => Id == carId)
        //}

        //public void RemoveCar()
        //{
        //    carCurrentBalance = Cars.ElementAt(carChoice - 1).Balance;
        //    if (carCurrentBalance <= 0)
        //    {
        //    }
        //    else
        //    {
        //        Cars.RemoveAt(carChoice - 1);
        //    }
        //}

        //public void LoadCarBalance()
        //{
        //    bool carChoiceValid = false;
        //    int carChoice = 0;
        //    double amount = 0;
        //    do
        //    {
        //        ShowCarsList();
        //        Console.WriteLine("Choose car number from the list above to be removed from parking.");
        //        carChoice = Convert.ToInt32(Console.ReadLine());
        //        if (1 <= carChoice && carChoice <= Cars.Count)
        //        {
        //            carChoiceValid = true;
        //            Console.WriteLine("Please enter amount to load on car number {0}", carChoice);
        //            amount = Convert.ToDouble(Console.ReadLine());
        //            Cars.ElementAt(carChoice - 1).LoadCarBalance(amount);
        //        }
        //        else { Console.WriteLine("Please choose valid car number from list"); }

        //    } while (!carChoiceValid);
        //}

        //public void ShowTransactionsHistory()
        //{
        //    foreach (Transaction tran in Transactions)
        //    {
        //        Console.WriteLine(tran);
        //    }
        //}

        //public void ShowRecentTransactionHistory()
        //{
        //    foreach (Transaction tran in Transactions)
        //    {
        //        TimeSpan diff = DateTime.Now.Subtract(tran.TransactionDateTime);
        //        if (diff.Minutes < 1)
        //        {
        //            Console.WriteLine(tran);
        //        }
        //    }
        //}

        //public void ShowTotalIncome()
        //{
        //    Console.WriteLine("Total parking income at this moment is {0}", Balance);
        //}

        public int GetParkingEmptySpots()
        {
            return Settings.ParkingSpace - Cars.Count;
        }

        public List<Car> GetCarsList()
        {
            Cars.Add(new Car(CarType.Bus, 100) );
            return Cars;
        }
    }
}
