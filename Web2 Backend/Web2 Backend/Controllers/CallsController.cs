using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CallsController : Controller
    {
        [Route("/api/calls/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [Route("/api/calls")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return null;
        }

        [Route("/api/calls")]
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            return Ok();
        }

        [Route("/api/calls/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id)
        {
            return Ok();
        }

        [Route("/api/calls/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
