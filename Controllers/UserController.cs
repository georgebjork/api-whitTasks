using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api_whitTasks.Models;

namespace api_whitTasks.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("api/users")]
        public ActionResult<List<User>> Get()
        {
            
            return api_whitTasks.Models.User.GetUser();
        }

        [Route("api/users/{id}")]
        public ActionResult<List<User>> Get(int id)
        {
            return api_whitTasks.Models.User.GetUser(id);
        }

        #region Post Methods
        [HttpPost]
        [Route("api/users/login")]
        public ActionResult<User> Login(User u)
        {
            User userToFind = api_whitTasks.Models.User.checkLogin(u);
            if(userToFind == u){
                return NotFound();
            }
            return userToFind;
        }

        #endregion

    }
}