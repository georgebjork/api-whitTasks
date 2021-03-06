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
        public string email {get; set;}
        public string password{get; set;}

        public User(){}

        public User(DataRow dr)
        {
            this.user_id = (int)dr["user_id"];
            this.first_name = (string)dr["first_name"];
            this.last_name = (string)dr["last_name"];
            this.date = (DateTime)dr["created_date"];
            this.email = (string)dr["email"];
            this.password = (string)dr["password"];
        }


        public static List<User> GetUser()
        {
            var ds = new Database().GetUser();
            return User.Fill(ds);
        }

        public static List<User> GetUser(int id)
        {
            var ds = new Database().GetUser(id);
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

        //This function given a user will retrive all users from a data base and see if it finds a matching username and password. If it does it will the user from the database
        public static User checkLogin(User u)
        {
            List<User> users = GetUser();
            for(int i = 0; i < users.Count(); i++){
                if(users[i].email == u.email && users[i].password == u.password)
                    return users[i];
            }

            return u;
        }
    }
}