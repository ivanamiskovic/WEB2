using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolutionController : Controller
    {
        [Route("/api/solutions/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [Route("/api/solutions")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return null;
        }

        [Route("/api/solutions")]
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            return Ok();
        }

        [Route("/api/solutions/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id)
        {
            return Ok();
        }

        [Route("/api/solutions/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
