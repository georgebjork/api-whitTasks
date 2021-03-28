using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using api_whitTasks.Models;

namespace api_whitTasks
{
    public class Database
    {
        internal string cstr;
        public Database()
        {
            cstr = DatabaseConnection.ConnectionString;
        }

        public static class DatabaseConnection
        {
            public static string ConnectionString { get; set; }
        }


        //These will run stored procedures we have created for our database 

        internal DataSet GetDataSet(string storedProcedure)
        {
            SqlDataAdapter adp = new SqlDataAdapter("exec " + storedProcedure, cstr);
            var ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }


        internal DataSet GetTask()
        {
            return GetTaskDataSet("get_tasks");
        } 

        internal DataSet GetUser()
        {
            return GetUserDataSet("get_users");
        }

        internal DataSet GetTaskDataSet(string storedProcedure)
        {
            var ds = GetDataSet(storedProcedure);
            //SetCourseDataSet(ref ds);
            return ds;
        }

          internal DataSet GetUserDataSet(string storedProcedure)
        {
            var ds = GetDataSet(storedProcedure);
            //SetCourseDataSet(ref ds);
            return ds;
        }
        
    }
}