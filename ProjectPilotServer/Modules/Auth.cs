using MySql.Data.MySqlClient;
using System.Data;

namespace ProjectPilotServer
{
    public class Auth
    {
        public static async Task Register(HttpContext context, IFormCollection form)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string username = form["username"];
            string password = form["password"];

            try
            {
                conn.Open();

                MySqlCommand check = conn.CreateCommand();

                check.CommandText = "SELECT * FROM users WHERE username = @username";
                check.Parameters.AddWithValue("@username", username);

                MySqlDataAdapter adapter = new MySqlDataAdapter(check);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    context.Response.StatusCode = 409;
                    await context.Response.WriteAsync($"Username already exists!");
                    return;
                }
                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = "INSERT INTO users(username,password) VALUES (@username,@password)";

                comm.Parameters.AddWithValue("@username", username);
                comm.Parameters.AddWithValue("@password", password);

                comm.ExecuteNonQuery();

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync($"Successfully created an account! \nusername: {username} \npassword: {password}");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Register error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public static async Task Login(HttpContext context, IFormCollection form)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string username = form["username"];
            string password = form["password"];

            try
            {
                conn.Open();

                MySqlCommand check = conn.CreateCommand();

                check.CommandText = "SELECT * FROM users WHERE username = @username AND password = @password";
                check.Parameters.AddWithValue("@username", username);
                check.Parameters.AddWithValue("@password", password);
                
                MySqlDataAdapter adapter = new MySqlDataAdapter(check);
                DataTable dt = new DataTable();

                if (dt.Rows.Count == 0) // if there is no such user with username and password
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync($"Incorrect information");
                    return;
                }

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync($"Successfully logged in!");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Login error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}