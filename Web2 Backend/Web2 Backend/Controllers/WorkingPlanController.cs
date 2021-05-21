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
    public class WorkingPlanController : Controller
    {
        public WorkingPlanController workingPlanService = new WorkingPlanController();

        [Route("/api/workingPlan/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(workingPlanService.Get(id));
        }

        [Route("/api/workingPlan")]
        [HttpGet]
        public PageResponse<WorkingPlan> GetAll()
        {
            return workingPlanService.GetAll();
        }

        [Route("/api/workingPlan")]
        [HttpPost]
        public async Task<IActionResult> Add(WorkingPlan workingPlan)
        {
            return Ok(workingPlanService.Add(workingPlan));
        }

        [Route("/api/workingPlan/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, WorkingPlan workingPlan)
        {
            return Ok(workingPlanService.Edit(id, workingPlan));
        }

        [Route("/api/workingPlan/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(workingPlanService.Delete(id));
        }
    }
}
