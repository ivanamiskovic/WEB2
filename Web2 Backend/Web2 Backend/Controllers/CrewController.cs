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
    public class CrewController : Controller
    {
        public CrewController crewService = new CrewController();

        [Route("/api/crew/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(crewService.Get(id));
        }

        [Route("/api/crew")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(crewService.GetAll());
        }

        [Route("/api/crew")]
        [HttpPost]
        public async Task<IActionResult> Add(Crew crew)
        {
            return Ok(crewService.Add(crew));
        }

        [Route("/api/crew/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Crew crew)
        {
            return Ok(crewService.Edit(id, crew));
        }

        [Route("/api/crew/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(crewService.Delete(id));
        }
    }
}
