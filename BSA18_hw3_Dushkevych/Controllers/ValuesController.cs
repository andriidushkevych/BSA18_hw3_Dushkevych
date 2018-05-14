using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingLib;
using Newtonsoft.Json;

namespace BSA18_hw3_Dushkevych.Controllers
{
    [Route("api/parking")]
    public class ValuesController : Controller
    {
        // GET api/parking/carlist
        [HttpGet("carlist")]
        public string GetCarList()
        {
            return JsonConvert.SerializeObject(Parking.ParkingInstance.Cars);
        }

        // GET api/parking/carlist/1
        [HttpGet("carlist/{id}")]
        public string GetCarDetailsById(int id)
        {
            return JsonConvert.SerializeObject(Parking.ParkingInstance.Cars.Where(x => x.Id == id));
        }

        // GET api/parking/emptyspots
        [HttpGet("emptyspots")]
        public string GetParkingEmptySpots()
        {
            return JsonConvert.SerializeObject(Parking.ParkingInstance.GetParkingEmptySpots());
        }

        // GET api/parking/busyspots
        [HttpGet("busyspots")]
        public string GetParkingBusySpots()
        {
            return JsonConvert.SerializeObject(Parking.ParkingInstance.Cars.Count);
        }

        // GET api/parking/totalincome
        [HttpGet("totalincome")]
        public string GetParkingTotalIncome()
        {
            return JsonConvert.SerializeObject(Parking.ParkingInstance.Balance);
        }

        // GET api/parking/transaction/log
        [HttpGet("transaction/log")]
        public string GetTransactionLog()
        {
            return JsonConvert.SerializeObject(Parking.ParkingInstance.GetTransactionsHistory());
        }

        // GET api/parking/transaction/recent
        [HttpGet("transaction/recent")]
        public string GetRecentParkingTransactions()
        {
            return JsonConvert.SerializeObject(Parking.ParkingInstance.GetRecentTransactionHistory());
        }

        // GET api/parking/transaction/recent/1
        [HttpGet("transaction/recent/{id}")]
        public string GetRecentCarTransactions(int id)
        {
            return JsonConvert.SerializeObject(Parking.ParkingInstance.GetRecentTransactionHistory().Where(x => x.CarId == id));
        }
        
        [HttpPost]
        public void AddCar(Car newCar)
        {
            Parking.ParkingInstance.AddCar(newCar);
        }

        // PUT api/parking/loadcarbalance/2/500
        [HttpPut("loadcarbalance/{id}/{amount}")]
        public void LoadCarBalance(int id, double amount)
        {
            Parking.ParkingInstance.LoadCarBalance(id, (double)amount);
        }

        // DELETE api/parking/car/remove/{id}
        [HttpDelete("car/remove/{id}")]
        public void RemoveCar(int id)
        {
            Parking.ParkingInstance.RemoveCar(id);
        }
    }
}
