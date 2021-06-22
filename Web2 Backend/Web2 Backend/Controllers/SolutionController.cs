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
    public class SolutionController : Controller
    {
        public SolutionService solutionService = new SolutionService();

        [Route("/api/solutions/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(solutionService.Get(id));
        }

        [Route("/api/solutions")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search)
        {
            return Ok(solutionService.GetAll());
        }

        [Route("/api/solutions")]
        [HttpPost]
        public async Task<IActionResult> Add(Solution solution)
        {
            return Ok(solutionService.Add(solution));
        }

        [Route("/api/solutions/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Solution solution)
        {
            return Ok(solutionService.Edit(id, solution));
        }

        [Route("/api/solutions/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(solutionService.Delete(id));
        }
    }
}
