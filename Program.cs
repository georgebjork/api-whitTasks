using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Data.SqlClient;
using System.Text;

namespace api_whitTasks
{
    public class Program
    {
        public static void Main(string[] args)
        {
             try 
            { 
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "whit-tasks.database.windows.net"; 
                builder.UserID = "whitTasks-admin";            
                builder.Password = "J0hn3:16";     
                builder.InitialCatalog = "whitTasks-database";
         
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");
                    
                    connection.Open();       

                    String sql = "EXEC get_tasks";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}", reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetBoolean(3), reader.GetBoolean(4), reader.GetInt32(5), reader.GetString(6));
                            }
                        }
                    }                    
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine(); 
        }
           
        }    
}
