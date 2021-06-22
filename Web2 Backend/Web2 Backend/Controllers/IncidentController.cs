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
    public class IncidentController : DefaultController
    {
        public IncidentService incidentService = new IncidentService();

        [Route("/api/incidents/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id) 
        {
            return Ok(incidentService.Get(id));
        }

        [Route("/api/incidents")]
        [HttpGet]
        public PageResponse<Incident> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search) 
        {
            return incidentService.GetAll();
        }

        [Route("/api/incidents")]
        [HttpPost]
        public async Task<IActionResult> Add(Incident incident)
        {
            incident.Operater = GetCurrentUser();
            return Ok(incidentService.Add(incident));
        }

        [Route("/api/incidents/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Incident incident)
        {
            return Ok(incidentService.Edit(id, incident));
        }

        [Route("/api/incidents/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(incidentService.Delete(id));
        }
    }
}
