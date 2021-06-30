using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web2_Backend.Model;
using Web2_Backend.Service;

namespace Web2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : Controller
    {
        public DeviceService service = new DeviceService();

        [Route("/api/devices/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(service.Get(id));
        }

        [Route("/api/devices")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search, [FromQuery(Name = "sort")] string sort)
        {
            return Ok(service.GetAll(page, perPage, search, sort));
        }

        [Route("/api/devices")]
        [HttpPost]
        public async Task<IActionResult> Add(Device device)
        {
            return Ok(service.Add(device));
        }

        [Route("/api/devices/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Device device)
        {
            return Ok(service.Edit(id, device));
        }

        [Route("/api/devices/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(service.Delete(id));
        }
    }
}
