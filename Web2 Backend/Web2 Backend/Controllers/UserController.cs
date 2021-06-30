using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [Route("/api/users/current")]
        [HttpGet]
        public async Task<IActionResult> GetCurrent(int id)
        {
            return Ok(GetCurrentUser());
        }

        [Route("/api/users/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [Route("/api/users")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage,
            [FromQuery(Name = "search")] string search)
        { 
            return Ok(userService.GetAll(page, perPage, search));
        }

        [Route("/api/users")]
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            return Ok(userService.Add(user));
        }

        [Route("/api/users")]
        [HttpPut]
        public async Task<IActionResult> Edit(User user)
        {
            userService.Edit(user);

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

        [Route("/api/users/verification")]
        [HttpGet]
        public async Task<IActionResult> VerificationUsers()
        {
            return Ok(userService.GetVerificationUsers());
        }

        [Route("/api/users/verification/{id}")]
        [HttpPut]
        public async Task<IActionResult> VerifyUser(long id)
        {
            return Ok(userService.VerifyUser(id));
        }

        [Authorize]
        [Route("/api/users/change-password")]
        [HttpPut]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            return Ok(userService.ChangePassword(changePasswordRequest.Password, GetCurrentUser().Id));
        }
    }
}
