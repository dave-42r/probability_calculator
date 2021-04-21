using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProbabilityCalculator.EndToEndTests;
using ProbabilityCalculator.UnitTests;
using Serilog;
using Serilog.Core;

namespace ProbabilityCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            SetupLogging();
            var calculatorUserInteractionService = new CalculatorUserInteractionService(new CalculatorService(), Log.Logger);

            calculatorUserInteractionService.StartUserCalculatorInteraction();
        }



        private static Logger SetupLogging()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithProperty("Version", "1.0.0")
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Infinite)
                .CreateLogger();
            Log.Logger = logger;

            Log.Logger.Information("Logging setup complete");

            return logger;
        }
    }
}
