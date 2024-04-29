using MySql.Data.MySqlClient;
using System.Data;

namespace TestBackend
{
    public class Connection
    {
        public static string server = "0.tcp.eu.ngrok.io"; // connection url, change when it is updated.
                                                           // when pushing into github, please make it blank!
                                                           // example: 2.tcp.eu.ngrok.io

        public static string port = "00000"; // connection port, change when it is updated.
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

        static async Task Register(HttpContext context, IFormCollection form)
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
                Console.WriteLine("Register error: "+ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        static async Task Login(HttpContext context, IFormCollection form)
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
                adapter.Fill(dt);

                if (dt.Rows.Count == 0) // if there is no such user with username and password
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync($"Incorrect information");
                    return;
                }

                context.Response.StatusCode = 200;
                await context.Response.WriteAsync($"Successfully logged in!");
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 500;
                Console.WriteLine("Login error: "+ex.ToString());
            }
            finally
            {
                conn.Close();
            }
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
                    // Extract username from query string
                    string requestType = context.Request.Query["requestType"];

                    switch (requestType)
                    {
                        default:
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsync($"{requestType} is not a recognized request type. (Get)");
                            break;
                    }
                });

                // POST REQUESTS //

                endpoints.MapPost("/", async context =>
                {
                    // Extract username from query string
                    string requestType = context.Request.Query["requestType"];
                    var form = await context.Request.ReadFormAsync();

                    switch (requestType)
                    {
                        case "register":
                            await Register(context, form);
                            break;

                        case "login":
                            await Login(context, form);
                            break;

                        default:
                            context.Response.StatusCode = 400;
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
                            context.Response.StatusCode = 400;
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
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsync($"{requestType} is not a recognized request type. (Put)");
                            break;
                    }
                });
            });
        }
    }
}
