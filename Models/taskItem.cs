namespace api_whitTasks.Models
{
    public class taskItem
    {
        public long task_id { get; set; }
        public long user_id { get; set; }
        public string name { get; set; }
        public bool done { get; set; }
        public bool delete { get; set; }
    }
}