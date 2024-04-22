using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Components.Forms;
using MySql.Data.MySqlClient;

namespace ProjectPilotServer
{
    public class Requirements
    {
        public static async Task PostRequirement(HttpContext context, IFormCollection form)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string name = form["name"];
            string project_id = form["project_id"];
            DateTime date = DateTime.Now;

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = "INSERT INTO requirements(date,deleted,name,project_id,status) VALUES (@date,0,@name,@project_id,@status)";

                comm.Parameters.AddWithValue("@date", date);
                comm.Parameters.AddWithValue("@status", "active");
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

                if (type == "name")
                {
                    comm.CommandText = "UPDATE requirements SET name=@name WHERE id=@id";

                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@name", name);

                    comm.ExecuteNonQuery();

                    await context.Response.WriteAsync("Success!");
                } 
                else if (type == "status")
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
