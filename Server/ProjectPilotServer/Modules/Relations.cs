using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectPilotServer
{
    public class Relations
    {
        // Getting relations
        public static async Task GetRelations(HttpContext context)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string requirement_id = context.Request.Query["requirement_id"];

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = "SELECT id, requirement_id, requirement_relation_id FROM requirement_relations WHERE requirement_id = @requirement_id";

                comm.Parameters.AddWithValue("@requirement_id", requirement_id);

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
                Console.WriteLine("Error getting relations: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        // Adding a new relation
        public static async Task AddRelation(HttpContext context, IFormCollection form)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string relation_type = form["type"];
            string requirement_id = form["requirement_id"];
            string relation_id = form["relation_id"];

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = "INSERT INTO requirement_relations(requirement_id,requirement_relation_id) VALUES (@requirement_id,@relation_id)";

                comm.Parameters.AddWithValue("@requirement_id", requirement_id);
                comm.Parameters.AddWithValue("@relation_id", relation_id);

                comm.ExecuteNonQuery();

                await context.Response.WriteAsync("Success!");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Error adding relation: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        // Deleting a relation
        public static async Task DeleteRelation(HttpContext context)
        {
            MySqlConnection conn = new MySqlConnection(Connection.connStr);

            string id = context.Request.Query["id"];

            try
            {
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = "DELETE FROM requirement_relations WHERE id = @id";

                comm.Parameters.AddWithValue("@id", id);

                comm.ExecuteNonQuery();

                await context.Response.WriteAsync("Success!");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Error deleting relation: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
