using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Service;

namespace Web2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CallsController : Controller
    {
        public CallsService callsService = new CallsService();

        [Route("/api/calls/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(callsService.Get(id));
        }

        [Route("/api/calls")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search)
        {
            return Ok(callsService.GetAll(page, perPage, search));
        }

        [Route("/api/calls")]
        [HttpPost]
        public async Task<IActionResult> Add(Calls calls)
        {
            return Ok(callsService.Add(calls));
        }

        [Route("/api/calls/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Calls calls)
        {
            return Ok(callsService.Edit(id, calls));
        }

        [Route("/api/calls/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(callsService.Delete(id));
        }
    }
}
