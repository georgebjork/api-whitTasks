using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api_whitTasks.Models;

namespace api_whitTasks.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("api/user")]
        public ActionResult<List<User>> Get()
        {
            
            return api_whitTasks.Models.User.GetUser();;
        }

    }
}