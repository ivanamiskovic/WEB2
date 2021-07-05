using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;

namespace Web2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentHistoryController : Controller
    {
        public DocumentHistoryController service = new DocumentHistoryController();

        [Route("/api/documentHistory/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(service.Get(id));
        }

        [Route("/api/documentHistory")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search, [FromQuery(Name = "sort")] string sort, [FromQuery(Name = "workRequestId")] int workRequestId)
        {
            return Ok(service.GetAll(page, perPage, search, sort, workRequestId));
        }

        [Route("/api/documentHistory")]
        [HttpPost]
        public async Task<IActionResult> Add(DocumentHistory documentHistory)
        {
            return Ok(service.Add(documentHistory));
        }

        [Route("/api/documentHistory/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, DocumentHistory documentHistory)
        {
            return Ok(service.Edit(id, documentHistory));
        }

        [Route("/api/documentHistory/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(service.Delete(id));
        }
    }
}

