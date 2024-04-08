namespace TestBackend
{
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
                    // Extract username from query string
                    string requesttype = context.Request.Query["requesttype"];

                    switch (requesttype)
                    {
                        default:
                            await context.Response.WriteAsync($"{requesttype} is not a recognized request type. (Get)");
                            break;
                    }
                });

                // POST REQUESTS //

                endpoints.MapPost("/", async context =>
                {
                    // Extract username from query string
                    string requesttype = context.Request.Query["requesttype"];

                    switch (requesttype)
                    {
                        default:
                            await context.Response.WriteAsync($"{requesttype} is not a recognized request type. (Post)");
                            break;
                    }
                });

                // DELETE REQUESTS //

                endpoints.MapDelete("/", async context =>
                {
                    // Extract username from query string
                    string requesttype = context.Request.Query["requesttype"];

                    switch (requesttype)
                    {
                        default:
                            await context.Response.WriteAsync($"{requesttype} is not a recognized request type. (Delete)");
                            break;
                    }
                });

                // PUT REQUESTS //

                endpoints.MapPut("/", async context =>
                {
                    // Extract username from query string
                    string requesttype = context.Request.Query["requesttype"];

                    switch (requesttype)
                    {
                        default:
                            await context.Response.WriteAsync($"{requesttype} is not a recognized request type. (Put)");
                            break;
                    }
                });
            });
        }
    }
}