using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace AspNetCore.BestPractices
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json", optional: false)
                 .Build();

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss.fff} {Level:u3}] {SourceContext}: {Message:lj}{NewLine}{Exception}")
            .WriteTo.File("bin/logs/log-.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(config.GetConnectionString("dbConnection"), "Logs", autoCreateSqlTable : true)
            .CreateLogger();


            try
            {
                Log.Information("Starting web host.");
                CreateWebHostBuilder(args).Build().Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
