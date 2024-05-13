using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Xml.Linq;

namespace ProjectPilotServer
{
    public class Roles
    {
        public static async Task GetRoles(HttpContext context)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string user_id = context.Request.Query["user_id"];
            string project_id = context.Request.Query["project_id"];

            try
            {
                conn.Open();

                MySqlCommand check = conn.CreateCommand();

                check.CommandText = "SELECT * FROM roles WHERE (@user_id IS NULL OR @user_id = '' OR user_id = @user_id) AND (@project_id IS NULL OR @project_id = '' OR project_id = @project_id)";
                check.Parameters.AddWithValue("@user_id", user_id);
                check.Parameters.AddWithValue("@project_id", project_id);

                MySqlDataAdapter adapter = new MySqlDataAdapter(check);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(dt));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Get roles error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public static async Task ControlRole(HttpContext context, IFormCollection form) // only for creating roles (if editing is also needed, it can be also added)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string user_id = form["user_id"];
            string project_id = form["project_id"];
            string name = form["name"];

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = "INSERT INTO roles (user_id, project_id, name) VALUES (@user_id, @project_id, @name)";

                comm.Parameters.AddWithValue("@user_id", user_id);
                comm.Parameters.AddWithValue("@project_id", project_id);
                comm.Parameters.AddWithValue("@name", name);

                comm.ExecuteNonQuery();

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Successfully created a role");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Create role error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public static async Task DeleteRole(HttpContext context)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string id = context.Request.Query["id"];

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = "DELETE FROM roles WHERE id = @id";

                comm.Parameters.AddWithValue("@id", id);

                comm.ExecuteNonQuery();

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Successfully deleted a role");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Delete role error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}