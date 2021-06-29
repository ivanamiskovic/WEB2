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

    public class SafetyDocumentController : DefaultController
    {
        public SafetyDocumentService safetyDocumentService = new SafetyDocumentService();

        [Route("/api/safetyDocuments/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(safetyDocumentService.Get(id));
        }

        [Route("/api/safetyDocuments")]
        [HttpGet]
        public PageResponse<SafetyDocument> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search, [FromQuery(Name = "mine")] bool mine)
        {
            return safetyDocumentService.GetAll(page, perPage, search, mine, GetCurrentUser());
        }

        [Route("/api/safetyDocuments")]
        [HttpPost]
        public async Task<IActionResult> Add(SafetyDocument safetyDocument)
        {
            return Ok(safetyDocumentService.Add(safetyDocument));
        }

        [Route("/api/safetyDocuments/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, SafetyDocument safetyDocument)
        {
            return Ok(safetyDocumentService.Edit(id, safetyDocument));
        }

        [Route("/api/safetyDocuments/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(safetyDocumentService.Delete(id));
        }
    }
}
