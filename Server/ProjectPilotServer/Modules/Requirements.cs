using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Components.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;

namespace ProjectPilotServer
{
    public class Requirements
    {
        // Getting all requirements of a project
        public static async Task GetRequirements(HttpContext context)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string project_id = context.Request.Query["project_id"];

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = "SELECT id, name, status, date, deleted FROM requirements WHERE project_id = @project_id";

                comm.Parameters.AddWithValue("@project_id", project_id);

                comm.ExecuteNonQuery();

                MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(dt));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Error getting requirements: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        // Adding a requirement to a project
        public static async Task PostRequirement(HttpContext context, IFormCollection form)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string name = form["name"];
            string project_id = form["project_id"];
            DateTime date = DateTime.Now; // Get the current time

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = "INSERT INTO requirements(date,deleted,name,project_id,status) VALUES (@date,0,@name,@project_id,@status)";

                comm.Parameters.AddWithValue("@date", date);
                comm.Parameters.AddWithValue("@status", "active"); // A requirement is active by default
                comm.Parameters.AddWithValue("@name", name);
                comm.Parameters.AddWithValue("@project_id", project_id);

                comm.ExecuteNonQuery();

                await context.Response.WriteAsync("Success!");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Error posting requirement: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        // Editing a requirement
        public static async Task EditRequirement(HttpContext context, IFormCollection form)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string type = form["type"];
            string id = form["id"];
            string name = form["name"];
            string status = form["status"];

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                if (type == "name") // Edit requirement's name
                {
                    comm.CommandText = "UPDATE requirements SET name=@name WHERE id=@id";

                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@name", name);

                    comm.ExecuteNonQuery();

                    await context.Response.WriteAsync("Success!");
                } 
                else if (type == "status") // Edit a requirement's status
                {
                    comm.CommandText = "UPDATE requirements SET status=@status WHERE id=@id";

                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@status", status);

                    comm.ExecuteNonQuery();

                    await context.Response.WriteAsync("Success!");
                }
                else
                {
                    await context.Response.WriteAsync("Not a recognized input!");
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Error editing a comment: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
