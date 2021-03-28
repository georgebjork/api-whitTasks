using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace api_whitTasks.Models
{
    public class User
    {
        public long user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime date {get; set; }

        public User(){}

        public User(DataRow dr)
        {
            this.user_id = (int)dr["user_id"];
            this.first_name = (string)dr["first_name"];
            this.last_name = (string)dr["last_name"];
            this.date = (DateTime)dr["created_date"];
        }


        public static List<User> GetUser()
        {
            var ds = new Database().GetUser();
            return User.Fill(ds);
        }


        public static List<User> Fill(DataSet ds)
        {
            var user = new List<User>();
             foreach (DataRow dr in ds.Tables[0].Rows)
            {
                user.Add(new User(dr));
            }
            return user;
        }
    }
}