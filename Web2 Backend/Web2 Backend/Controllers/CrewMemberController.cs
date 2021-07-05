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
    public class CrewMemberController : Controller
    {
        public CrewMemberService crewMemberService = new CrewMemberService();

        [Route("/api/crewMembers/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(crewMemberService.Get(id));
        }

        [Route("/api/crewMembers")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search, [FromQuery(Name = "sort")] string sort)
        {
            return Ok(crewMemberService.GetAll(page, perPage, search, sort));
        }

        [Route("/api/crewMembers")]
        [HttpPost]
        public async Task<IActionResult> Add(CrewMember crewMember)
        {
            return Ok(crewMemberService.Add(crewMember));
        }

        [Route("/api/crewMembers/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, CrewMember crewMember)
        {
            return Ok(crewMemberService.Edit(id, crewMember));
        }

        [Route("/api/crewMembers/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(crewMemberService.Delete(id));
        }
    }
}
