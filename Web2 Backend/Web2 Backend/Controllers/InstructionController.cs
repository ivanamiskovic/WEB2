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
    public class InstructionController : DefaultController
    {
        public InstructionsService incidentService = new InstructionsService();

        [Route("/api/instructions/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(incidentService.Get(id));
        }

        [Route("/api/instructions")]
        [HttpGet]
        public PageResponse<Instructions> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search, [FromQuery(Name = "mine")] bool mine, [FromQuery(Name = "sort")] string sort)
        {
            return incidentService.GetAll(page, perPage, search, sort);
        }

        [Route("/api/instructions")]
        [HttpPost]
        public async Task<IActionResult> Add(Instructions instruction)
        {
            
            return Ok(incidentService.Add(instruction));
        }

        [Route("/api/instructions/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Instructions instruction)
        {
            return Ok(incidentService.Edit(id, instruction));
        }

        [Route("/api/instructions/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(incidentService.Delete(id));
        }
    }
}
