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
    public class MultimediaAttachmentsController : DefaultController
    {
        public MultimediaAttachmentsService multimediaService = new MultimediaAttachmentsService();

        [Route("/api/multimediaAttachments/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(multimediaService.Get(id));
        }

        [Route("/api/multimediaAttachments")]
        [HttpGet]
        public PageResponse<MultimediaAttachments> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search, [FromQuery(Name = "sort")] string sort)
        {
            return multimediaService.GetAll(page, perPage, search, sort);
        }

        [Route("/api/multimediaAttachments")]
        [HttpPost]
        public async Task<IActionResult> Add(MultimediaAttachments multimediaAttachments)
        {
            return Ok(multimediaService.Add(multimediaAttachments));
        }

        [Route("/api/multimediaAttachments/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, MultimediaAttachments multimediaAttachments)
        {
            return Ok(multimediaService.Edit(id, multimediaAttachments));
        }

        [Route("/api/multimediaAttachments/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(multimediaService.Delete(id));
        }
    }
}
