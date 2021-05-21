using System;
using System.Threading.Tasks;
using HomiePages.Infrastructure.Identity;
using HomiePages.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HomiePages.WebUI {
    public class Program {
        public async static Task Main (string[] args) {
            var host = CreateHostBuilder (args)
                .ConfigureLogging((hostingContext, logging) => {
                    logging.AddFile("logs/homiepagesApi-{Date}.txt");
                }).Build();

            using (var scope = host.Services.CreateScope ()) {
                var services = scope.ServiceProvider;

                try {
                    var context = services.GetRequiredService<ApplicationDbContext> ();

                    if (context.Database.IsSqlServer ()) {
                        context.Database.Migrate ();
                    }

                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>> ();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>> ();

                    await ApplicationDbContextSeed.SeedDefaultUserAsync (userManager, roleManager);
                    await ApplicationDbContextSeed.SeedSampleDataAsync (context);
                } catch (Exception ex) {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>> ();

                    logger.LogError (ex, "An error occurred while migrating or seeding the database.");

                    throw;
                }
            }

            await host.RunAsync ();
        }

        public static IHostBuilder CreateHostBuilder (string[] args) =>
            Host.CreateDefaultBuilder (args)
            .ConfigureWebHostDefaults (webBuilder => {
                webBuilder.UseStartup<Startup> ();
            });
    }
}