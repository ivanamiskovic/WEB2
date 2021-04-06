using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [Route("/api/users/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [Route("/api/users")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            return null;
        }

        [Route("/api/users")]
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            return Ok();
        }

        [Route("/api/users/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id)
        {
            return Ok();
        }

        [Route("/api/users/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
