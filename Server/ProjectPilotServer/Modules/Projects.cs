using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;

namespace ProjectPilotServer
{
    public class Projects
    {
        public static async Task GetProjects(HttpContext context)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            try
            {
                conn.Open();

                MySqlCommand check = conn.CreateCommand();

                check.CommandText = "SELECT * FROM projects";

                MySqlDataAdapter adapter = new MySqlDataAdapter(check);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(dt));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Get projects error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public static async Task ControlProject(HttpContext context, IFormCollection form) // both for project creation and editing
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string id = form["id"];
            string name = form["name"];
            string description = form["description"];
            string status = form["status"];

            try // this works like a piece of
                // very good software
                // when you have edit a project, you have to basically specify every parameter of a row
                // even if it is not changed
            {
                conn.Open();

                if (id != null && id != "") // if id is not null and not empty, edit the project
                                            // maybe there is a more correct way?
                {
                    MySqlCommand comm = conn.CreateCommand();

                    comm.CommandText = "UPDATE projects SET name = @name, description = @description, status = @status WHERE id = @id";

                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@name", name);
                    comm.Parameters.AddWithValue("@description", description);
                    comm.Parameters.AddWithValue("@status", status);

                    comm.ExecuteNonQuery();

                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Successfully edited a project"); // well i couldnt obviously tell that it is successful
                                                                                        // without this piece of information
                                                                                        // should it even be included if the status code is already 200?
                }
                else // if id is empty, create a new project
                {
                    MySqlCommand comm = conn.CreateCommand();

                    comm.CommandText = "INSERT INTO projects (name, description, status) VALUES (@name, @description, 'active')";

                    comm.Parameters.AddWithValue("@name", name);
                    comm.Parameters.AddWithValue("@description", description);

                    comm.ExecuteNonQuery();

                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Successfully created a project");
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Control project error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}