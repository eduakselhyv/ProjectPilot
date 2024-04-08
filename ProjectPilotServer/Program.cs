using MySql.Data.MySqlClient;

namespace TestBackend
{
    public class Connection
    {
        public static string server = "0.tcp.eu.ngrok.io"; // connection url, change when it is updated.
                                                           // when pushing into github, please make it blank!
                                                           // example: 2.tcp.eu.ngrok.io

        public static string port = "19725"; // connection port, change when it is updated.
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

                    switch (requestType)
                    {
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