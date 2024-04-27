using Microsoft.AspNetCore.Components.Forms;
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
                    comm.CommandText =
                        "SELECT u.username, c.value, c.edited, c.created " +
                        "FROM comments c " +
                        "JOIN users u ON c.user_id = u.id " +
                        "WHERE project_id = @project_id";
                    comm.Parameters.AddWithValue("@project_id", project_id);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(dt));
                }
                else if (type == "reply")
                {
                    comm.CommandText =
                        "SELECT u.username, c.value, c.edited, c.created " +
                        "FROM comments c " +
                        "JOIN users u ON c.user_id = u.id " +
                        "WHERE comment_id = @comment_id";
                    comm.Parameters.AddWithValue("@comment_id", comment_id);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(dt));
                }
                else if (type == "requirement")
                {
                    comm.CommandText =
                        "SELECT u.username, c.value, c.edited, c.created " +
                        "FROM comments c " +
                        "JOIN requirement_comment_relations rcr ON c.id = rcr.comment_id " +
                        "JOIN users u ON c.user_id = u.id " +
                        "WHERE rcr.requirement_id = @requirement_id";

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
            string requirement_id = form["requirement_id"];
            string user_id = form["user_id"];
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
                    comm.Parameters.AddWithValue("@deleted", 0);

                    comm.ExecuteNonQuery();

                    context.Response.StatusCode = 200;
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
                    comm.Parameters.AddWithValue("@deleted", 0);

                    comm.ExecuteNonQuery();

                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Success!");
                }
                else if (type == "requirement")
                {
                    comm.CommandText = "INSERT INTO comments(created,user_id,type,value,deleted) VALUES (@created,@user_id,@type,@value,@deleted); SELECT LAST_INSERT_ID();";

                    comm.Parameters.AddWithValue("@created", created);
                    comm.Parameters.AddWithValue("@user_id", user_id);
                    comm.Parameters.AddWithValue("@type", type);
                    comm.Parameters.AddWithValue("@value", value);
                    comm.Parameters.AddWithValue("@deleted", 0);

                    var id = comm.ExecuteScalar();

                    // Convert the retrieved ID to the appropriate data type
                    int newCommentId = Convert.ToInt32(id);

                    MySqlCommand comm2 = conn.CreateCommand();

                    comm2.CommandText = "INSERT INTO requirement_comment_relations(comment_id, requirement_id) VALUES (@comment_id, @requirement_id)";
                    comm2.Parameters.AddWithValue("@comment_id", newCommentId);
                    comm2.Parameters.AddWithValue("@requirement_id", requirement_id);
                    comm2.ExecuteNonQuery();

                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Success!");

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

        public static async Task EditComment(HttpContext context, IFormCollection form)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string id = form["id"];
            string value = form["value"];
            DateTime edited = DateTime.Now;

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = "UPDATE comments SET value=@value,edited=@edited WHERE id=@id";

                comm.Parameters.AddWithValue("@id", id);
                comm.Parameters.AddWithValue("@value", value);
                comm.Parameters.AddWithValue("@edited", edited);

                comm.ExecuteNonQuery();

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Success!");
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

        public static async Task DeleteComment(HttpContext context)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string id = context.Request.Query["id"];

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = "UPDATE comments SET deleted=1 WHERE id=@id OR comment_id=@id";

                comm.Parameters.AddWithValue("@id", id);

                comm.ExecuteNonQuery();

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Success!");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Error deleting a comment: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
