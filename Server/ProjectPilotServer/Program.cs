namespace ProjectPilotServer
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
                    string requestType = context.Request.Query["requestType"];

                    switch (requestType)
                    {
                        case "projects":
                            await Projects.GetProjects(context);
                            break;
                        case "roles":
                            await Roles.GetRoles(context);
                            break;
                        case "users":
                            await Users.GetUsers(context);
                            break;
                        case "comments":
                            await Comments.GetComments(context); // For getting comments
                            break;
                        case "requirements":
                            await Requirements.GetRequirements(context); // For getting requirements
                            break;
                        case "relations":
                            await Relations.GetRelations(context); // For getting relations
                            break;
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
                            await Auth.Register(context, form);
                            break;

                        case "login":
                            await Auth.Login(context, form);
                            break;

                        case "project":
                            await Projects.ControlProject(context, form); // both for creating and editing a project
                            break;

                        case "comment":
                            await Comments.PostComment(context, form);
                            break;

                        case "requirement":
                            await Requirements.PostRequirement(context, form);
                            break;

                        case "relation":
                            await Relations.AddRelation(context, form);
                            break;
                            
                        case "role":
                            await Roles.ControlRole(context, form); // both for creating and editing a project
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
                        case "comment":
                            await Comments.DeleteComment(context);
                            break;

                        case "relation":
                            await Relations.DeleteRelation(context);
                            break;

                        case "role":
                            await Roles.DeleteRole(context);
                            break;
                            
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
                    var form = await context.Request.ReadFormAsync();

                    switch (requestType)
                    {
                        case "comment":
                            await Comments.EditComment(context, form);
                            break;
                        case "requirement":
                            await Requirements.EditRequirement(context, form);
                            break;
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
