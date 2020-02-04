using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ToDoAPI.Data;
using ToDoAPI.Models;

namespace ToDoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                try{
                    var repo = services.GetRequiredService<IRepository>();
                    InitRepository(repo);
                }catch(Exception exc){
                    var logger = services.GetService<ILogger<Program>>();
                    logger.LogError(exc, "An error occured while seeding repository");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        static void InitRepository(IRepository repo)
        {
            if(repo.IsEmpty<ToDoItem>()) {
                repo.AddRange<ToDoItem>(
                        
                );
            }
        }
    }
}
