using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Service;
using Cosumer = Web2_Backend.Model.Cosumer;

namespace Web2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CosumerController : Controller
    {
        public CosumerService cosumerService = new CosumerService();

        [Route("/api/consumers/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(cosumerService.Get(id));
        }

        [Route("/api/consumers")]
        [HttpGet]
        public PageResponse<Cosumer> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search)
        {
            return cosumerService.GetAll();
        }

        [Route("/api/consumers")]
        [HttpPost]
        public async Task<IActionResult> Add(Cosumer cosumer)
        {
            return Ok(cosumerService.Add(cosumer));
        }

        [Route("/api/consumers/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Cosumer cosumer)
        {
            return Ok(cosumerService.Edit(id, cosumer));
        }

        [Route("/api/consumers/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(cosumerService.Delete(id));
        }
    }


}
