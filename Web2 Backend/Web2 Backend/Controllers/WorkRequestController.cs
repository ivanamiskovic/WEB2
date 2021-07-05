using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web2_Backend.Model;
using Web2_Backend.Model.Request;
using Web2_Backend.Service;

namespace Web2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkRequestController : DefaultController
    {
        public WorkRequestService service = new WorkRequestService();

        [Route("/api/work-requests/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(service.Get(id));
        }

        [Route("/api/work-requests")]
        [HttpGet]
        public PageResponse<WorkRequest> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search, [FromQuery(Name = "mine")] bool mine, [FromQuery(Name = "sort")] string sort)
        {
            return service.GetAll(page, perPage, search, mine, GetCurrentUser(), sort);
        }

        [Route("/api/work-requests")]
        [HttpPost]
        public async Task<IActionResult> Add(WorkRequest workRequest)
        {
            return Ok(service.Add(workRequest, GetCurrentUser()));
        }

        [Route("/api/work-requests/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, WorkRequest workRequest)
        {
            return Ok(service.Edit(id, workRequest));
        }

        [Route("/api/work-requests/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(service.Delete(id));
        }

        [Route("/api/work-requests-change-state/{id}")]
        [HttpPost]
        public async Task<IActionResult> ChangeState(WorkRequestChangeStatusRequest data)
        {
            return Ok(service.ChangeState(data, GetCurrentUser()));
        }


    }

}