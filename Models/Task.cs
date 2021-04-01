using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace api_whitTasks.Models
{
    public class Task
    {
        public long task_id { get; set; }
        public long user_id { get; set; }
        public string name { get; set; }
        public bool done { get; set; }
        public bool delete { get; set; }

        public Task(){}

        public Task(DataRow dr)
        {
            this.task_id = (int)dr["task_id"];
            this.user_id = (int)dr["user_id"];
            this.name = (string)dr["name"];
            this.done = (bool) dr ["done"];
            this.delete = (bool) dr ["deleted"];
        }

        public static List<Task> GetTask()
        {
            var ds = new Database().GetTask();
            return Task.Fill(ds);
        }
        public static List<Task> GetTask(int id)
        {
             var ds = new Database().GetTask(id);
            return Task.Fill(ds);
        }
        public static List<Task> Fill(DataSet ds)
        {
            var task = new List<Task>();
             foreach (DataRow dr in ds.Tables[0].Rows)
            {
                task.Add(new Task(dr));
            }
            return task;
        }
    }


}