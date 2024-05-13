using MySql.Data.MySqlClient;
using System.Data;
using Newtonsoft.Json;

namespace ProjectPilotServer
{
    public class Users
    {
        public static async Task GetUsers(HttpContext context)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            try
            {
                conn.Open();

                MySqlCommand check = conn.CreateCommand();

                check.CommandText = "SELECT * FROM users";

                MySqlDataAdapter adapter = new MySqlDataAdapter(check);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(dt));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("User retrieval error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}