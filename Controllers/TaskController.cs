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
            return Task.GetTaskList();
        }

        [Route("api/tasks/{id}")]
        public ActionResult<List<Task>> Get(int id)
        {
            return Task.GetTaskList(id);
        }

        #region Post Methods
        [HttpPost]
        //[EnableCors("api-CORS")]
        [Route("api/tasks")]
        public ActionResult<Task> addTask(Task task)
        {
            //Create a task with the vars being passed in
            return Task.addTask(task);
        }

        #endregion
    }
}