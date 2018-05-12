using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLib
{
    public class Settings
    {
        private static Dictionary<CarType, int> parkingPrice = new Dictionary<CarType, int>()
        {
            { CarType.Passenger, 3 },
            { CarType.Truck, 5 },
            { CarType.Bus, 2 },
            { CarType.Motorcycle, 1 }
        };

        public static int Timeout { get; private set; } = 3;
        public static Dictionary<CarType, int> ParkingPrice { get { return parkingPrice; } }
        public static int ParkingSpace { get; private set; } = 10;
        public static float Fine { get; private set; } = 1.5f;
    }
}
