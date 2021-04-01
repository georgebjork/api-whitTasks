using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api_whitTasks.Models;

namespace api_whitTasks.Controllers
{
    [ApiController]
    public class TaskController : ControllerBase
    {
        [Route("api/tasks")]
        public ActionResult<List<Task>> Get()
        {
            return Task.GetTask();
        }

        [Route("api/tasks/{id}")]
        public ActionResult<List<Task>> Get(int id)
        {
            return Task.GetTask(id);
        }
    }
}