using MySql.Data.MySqlClient;
using Mysqlx;
using System.Data;

namespace TestBackend
{
    public class Connection
    {
        public static string server = "5.tcp.eu.ngrok.io"; // connection url, change when it is updated.
                                                           // when pushing into github, please make it blank!
                                                           // example: 2.tcp.eu.ngrok.io

        public static string port = "13314"; // connection port, change when it is updated.
                                             // when pushing into github, please make it blank as well!
                                             // example: 19672

        public static string database = "project_pilot";
        public static string user = "root";
        public static string password = "admin";

        public static string connStr =
            "server=" + server + ";" +
            "port=" + port + ";" +
            "database=" + database + ";" +
            "uid=" + user + ";" +
            "password=" + password + ";";
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:5000"); // Specify the port number here
                });
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure any services your application requires
            // For example: services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Define how your application handles HTTP requests
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                // GET REQUESTS //

                endpoints.MapGet("/", async context =>
                {
                    try
                    {
                        MySqlConnection conn = new MySqlConnection(Connection.connStr);
                        conn.Open();

                        // Extract username from query string
                        string requestType = context.Request.Query["requestType"];

                        switch (requestType)
                        {
                            default:
                                await context.Response.WriteAsync($"{requestType} is not a recognized request type. (Get)");
                                break;
                        }

                        conn.Close();
                        
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                });

                // POST REQUESTS //

                endpoints.MapPost("/", async context =>
                {
                    // Extract username from query string
                    string requestType = context.Request.Query["requestType"];
                    var form = await context.Request.ReadFormAsync();

                    string username = "";
                    string password = "";

                    switch (requestType)
                    {
                        case "register":
                            username = form["username"];
                            password = form["password"];

                            try
                            {
                                MySqlConnection conn = new MySqlConnection(Connection.connStr);
                                conn.Open();

                                MySqlCommand check = conn.CreateCommand();

                                check.CommandText = "SELECT * FROM users WHERE username = @username";
                                check.Parameters.AddWithValue("@username", username);

                                MySqlDataAdapter adapter = new MySqlDataAdapter(check);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                if (dt.Rows.Count == 0)
                                {
                                    MySqlCommand comm = conn.CreateCommand();

                                    comm.CommandText = "INSERT INTO users(username,password) VALUES (@username,@password)";

                                    comm.Parameters.AddWithValue("@username", username);
                                    comm.Parameters.AddWithValue("@password", password);

                                    comm.ExecuteNonQuery();

                                    await context.Response.WriteAsync($"Successfully created an account! \nusername: {username} \npassword: {password}");

                                    conn.Close();

                                }
                                else
                                {
                                    await context.Response.WriteAsync($"Username already exists!");
                                    conn.Close();
                                }

                            } catch (Exception e)
                            {
                                await context.Response.WriteAsync($"Error creating an account! {e.ToString()}");
                            }
                            break;

                        case "login":
                            username = form["username"];
                            password = form["password"];
                            await context.Response.WriteAsync($"Successfully logged in!");
                            break;

                        default:
                            await context.Response.WriteAsync($"{requestType} is not a recognized request type. (Post)");
                            break;
                    }
                });

                // DELETE REQUESTS //

                endpoints.MapDelete("/", async context =>
                {
                    // Extract username from query string
                    string requestType = context.Request.Query["requestType"];

                    switch (requestType)
                    {
                        default:
                            await context.Response.WriteAsync($"{requestType} is not a recognized request type. (Delete)");
                            break;
                    }
                });

                // PUT REQUESTS //

                endpoints.MapPut("/", async context =>
                {
                    // Extract username from query string
                    string requestType = context.Request.Query["requestType"];

                    switch (requestType)
                    {
                        default:
                            await context.Response.WriteAsync($"{requestType} is not a recognized request type. (Put)");
                            break;
                    }
                });
            });
        }
    }
}