using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Configuration;
using Web2_Backend.Model;
using Web2_Backend.Service;

namespace Web2_Backend.Controllers
{
    public class DefaultController : Controller
    {
        protected UserService userService = new UserService();
        protected ProjectConfiguration configuration;

        public DefaultController(ProjectConfiguration configuration) 
        {
            this.configuration = configuration;
        }

        public DefaultController() { }

        protected User GetCurrentUser() 
        {
            string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Email").Value;

            return userService.GetUserWithEmail(email);
        }


    }
}
