using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Model.Request;
using Web2_Backend.Service;

namespace Web2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : DefaultController
    {
        private UserService userService = new UserService();

        [Route("/api/users/current")]
        [HttpGet]
        public async Task<IActionResult> GetCurrent(int id)
        {
            return Ok(GetCurrentUser());
        }

        [Route("/api/users/{id}")]




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
        public async Task<IActionResult> Add(User user)
        {
            return Ok(userService.Add(user));
        }

        [Route("/api/users/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, User user)
        {
            return Ok();
        }

        [Route("/api/users/change-user-type")]
        [HttpPut]
        public async Task<IActionResult> ChangeUserType(ChangeUserTypeRequest request)
        {
            return Ok(userService.ChangeUserType(request));
        }

        [Route("/api/users/admin-approve")]
        [HttpPut]
        public async Task<IActionResult> AdminNeedApproved(AdminNeedApprovedRequest request)
        {
            return Ok(userService.AdminNeedApproved(request));
        }

        [Route("/api/users/change-user-status")]
        [HttpPut]
        public async Task<IActionResult> ChangeUserStatus(ChangeUserStatusRequest request)
        {
            return Ok(userService.ChangeUserStatus(request));
        }

        [Route("/api/users/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
