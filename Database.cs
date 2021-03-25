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
    }
}