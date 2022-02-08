using CBMS.BAL.Service;
using CBMS.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusStopController : ControllerBase
    {
        private BusStopService _busStopService;
        public BusStopController(BusStopService busStopService)
        {
            _busStopService = busStopService;
        }

        [HttpPost("AddBusStop")]
        public IActionResult AddBusStop([FromBody] BusStop busstop)
        {
            _busStopService.AddBusStop(busstop);

            return Ok("Bus Stop Details Added Successfully!!!");
        }

        [HttpGet("GetBusStop")]
        public IEnumerable<BusStop> GetBusStop()
        {
            return _busStopService.GetBusStop();
        }

        [HttpDelete("DeleteBusStop")]
        public IActionResult DeleteBusStop(int busno)
        {
            _busStopService.DeleteBusStop(busno);
            return Ok("Bus Stop Details Deleted Successfully!!!");
        }

        [HttpPut("UpdateBusStop")]
        public IActionResult UpdateBusStop([FromBody] BusStop busstop)
        {
            _busStopService.UpdateBusStop(busstop);
            return Ok("Bus Stop Details Updated Successfully!!!");
        }
    }
}
