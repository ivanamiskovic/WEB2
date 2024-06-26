﻿using Microsoft.AspNetCore.Mvc;
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
    public class SwitchingPlanController : DefaultController
    {
        public SwitchingPlanService switchingPlanService = new SwitchingPlanService();

        [Route("/api/switchingPlans/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(switchingPlanService.Get(id));
        }

        [Route("/api/switchingPlans")]
        [HttpGet]
        public PageResponse<SwitchingPlan> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search, [FromQuery(Name = "mine")] bool mine, [FromQuery(Name = "sort")] string sort)
        {
            return switchingPlanService.GetAll(page, perPage, search, mine, GetCurrentUser(), sort);
        }

        [Route("/api/switchingPlans")]
        [HttpPost]
        public async Task<IActionResult> Add(SwitchingPlan switchingPlan)
        {
            return Ok(switchingPlanService.Add(switchingPlan));
        }

        [Route("/api/switchingPlans/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, SwitchingPlan switchingPlan)
        {
            return Ok(switchingPlanService.Edit(id, switchingPlan));
        }

        [Route("/api/switchingPlans/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(switchingPlanService.Delete(id));
        }
    }




}
