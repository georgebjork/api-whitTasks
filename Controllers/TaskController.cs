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
        public ActionResult<List<Task>> GetTasks()
        {
            return Task.GetTaskList();
        }

        [Route("api/tasks/{id}")]
        //Return as list of tasks by a user id
        public ActionResult<List<Task>> GetTasks(int id)
        {
            return Task.GetTaskList(id);
        }

        [Route("api/task/{task_id}")]
        //Return a single task by the task id
        public ActionResult<Task> GetTask(int task_id)
        {
            return Task.GetTask(task_id);
        }

        #region Post Methods
        [HttpPost]
        //[EnableCors("api-CORS")]
        [Route("api/tasks")]
        public ActionResult<Task> addTask([FromBody] Task task)
        {
            //Create a task with the vars being passed in
            //Task task = new Task(t, id);
            return Task.addTask(task);

        }

        #endregion

        #region Put Mehods
        [HttpPost]
        [Route("api/tasks/{id}")]

        public ActionResult<Task> editTask(int id, [FromBody] Task task)
        {

            if (task == null)
            {
                return BadRequest("the object given is null");
            }
            //Task task1 = this.GetTask(id);



            return NoContent();
        }

        #endregion
    }
}