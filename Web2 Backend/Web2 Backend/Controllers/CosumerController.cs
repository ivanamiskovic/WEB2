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
        public CosumerController cosumerService = new CosumerController();

        [Route("/api/cosumer/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(cosumerService.Get(id));
        }

        [Route("/api/cosumer")]
        [HttpGet]
        public PageResponse<Cosumer> GetAll()
        {
            return cosumerService.GetAll();
        }

        [Route("/api/cosumer")]
        [HttpPost]
        public async Task<IActionResult> Add(Cosumer cosumer)
        {
            return Ok(cosumerService.Add(cosumer));
        }

        [Route("/api/cosumer/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Cosumer cosumer)
        {
            return Ok(cosumerService.Edit(id, cosumer));
        }

        [Route("/api/cosumer/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(cosumerService.Delete(id));
        }
    }


}
