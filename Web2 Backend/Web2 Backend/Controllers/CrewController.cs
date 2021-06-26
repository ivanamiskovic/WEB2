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
        public CrewService crewService = new CrewService();

        [Route("/api/crews/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(crewService.Get(id));
        }

        [Route("/api/crews")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search)
        {
            return Ok(crewService.GetAll(page, perPage, search));
        }

        [Route("/api/crews")]
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

        [Route("/api/crews/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(crewService.Delete(id));
        }
    }
}
