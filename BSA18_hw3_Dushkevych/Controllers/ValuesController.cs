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

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
