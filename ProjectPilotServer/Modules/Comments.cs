using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Newtonsoft.Json;
using System.Data;

namespace ProjectPilotServer
{
    public class Comments
    {
        public static async Task GetComments(HttpContext context)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string type = context.Request.Query["type"];
            string project_id = context.Request.Query["project_id"];
            string comment_id = context.Request.Query["comment_id"];
            string requirement_id = context.Request.Query["requirement_id"];


            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                if (type == "project")
                {
                    comm.CommandText = "SELECT value, user_id FROM comments WHERE project_id = @project_id";
                    comm.Parameters.AddWithValue("@project_id", project_id);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(dt));
                }
                else if (type == "reply")
                {
                    comm.CommandText = "SELECT value, user_id FROM comments WHERE comment_id = @comment_id";
                    comm.Parameters.AddWithValue("@comment_id", comment_id);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(dt));
                }
                else if (type == "requirement")
                {
                    comm.CommandText = "SELECT comment_id FROM requirement_relations WHERE requirement_id = @requirement_id";
                    comm.Parameters.AddWithValue("@requirement_id", requirement_id);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(dt));
                }

            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Error getting comments: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    
        public static async Task PostComment(HttpContext context, IFormCollection form)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);


            string type = form["type"];
            string value = form["value"];
            string project_id = form["project_id"];
            string comment_id = form["comment_id"];
            string user_id = form["user_id"];
            bool deleted = Convert.ToBoolean(form["deleted"]);
            DateTime created = DateTime.Now;

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                if (type == "project")
                {

                    comm.CommandText = "INSERT INTO comments(created,project_id,user_id,type,value,deleted) VALUES (@created,@project_id,@user_id,@type,@value,@deleted)";

                    comm.Parameters.AddWithValue("@created", created);
                    comm.Parameters.AddWithValue("@project_id", project_id);
                    comm.Parameters.AddWithValue("@user_id", user_id);
                    comm.Parameters.AddWithValue("@type", type);
                    comm.Parameters.AddWithValue("@value", value);
                    comm.Parameters.AddWithValue("@deleted", deleted);

                    comm.ExecuteNonQuery();

                    await context.Response.WriteAsync("Success!");
                }
                else if (type == "reply")
                {
                    comm.CommandText = "INSERT INTO comments(created,comment_id,user_id,type,value,deleted) VALUES (@created,@comment_id,@user_id,@type,@value,@deleted)";

                    comm.Parameters.AddWithValue("@created", created);
                    comm.Parameters.AddWithValue("@comment_id", comment_id);
                    comm.Parameters.AddWithValue("@user_id", user_id);
                    comm.Parameters.AddWithValue("@type", type);
                    comm.Parameters.AddWithValue("@value", value);
                    comm.Parameters.AddWithValue("@deleted", deleted);

                    comm.ExecuteNonQuery();

                    await context.Response.WriteAsync("Success!");
                }
                else if (type == "requirement")
                {

                }

            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Error posting comment: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
