using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api_whitTasks.Models;

namespace api_whitTasks.Controllers
{
    [ApiController]
    public class TaskController : ControllerBase
    {
        [Route("api/task")]
        public ActionResult<List<Task>> Get()
        {
            return Task.GetTask();
        }

    }
}