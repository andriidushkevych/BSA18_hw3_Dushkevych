using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLib
{
    public class Transaction
    {
        public DateTime TransactionDateTime { get; private set; }
        public int CarId { get; private set; }
        public double ChargedAmount { get; private set; }

        public Transaction(int carIdArg, double chargedAmountArg)
        {
            TransactionDateTime = DateTime.Now;
            CarId = carIdArg;
            ChargedAmount = chargedAmountArg;
        }
    }
}
