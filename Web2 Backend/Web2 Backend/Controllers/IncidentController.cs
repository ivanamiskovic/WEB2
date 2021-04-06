using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;

namespace Web2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController : Controller
    {
        [Route("/api/incidents/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id) 
        {
            return Ok();
        }

        [Route("/api/incidents")]
        [HttpGet]
        public PageResponse<Incident> GetAll() 
        {
            return null;
        }

        [Route("/api/incidents")]
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            return Ok();
        }

        [Route("/api/incidents/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id)
        {
            return Ok();
        }

        [Route("/api/incidents/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
