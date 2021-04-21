using System;
using ProbabilityCalculator.UnitTests;
using Serilog;

namespace ProbabilityCalculator.EndToEndTests
{
    public class CalculatorUserInteractionService:ICalculatorUserInteractionService
    {
        private readonly ICalculatorService _calculatorService;
        private readonly ILogger _logger;

        public CalculatorUserInteractionService(ICalculatorService calculatorService, ILogger logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
        }
        
        public decimal StartUserCalculatorInteraction()
        {
            _logger.Information("Hello and welcome to the Probability Calculator");
            _logger.Information("Please enter the first valid probability(0.0 >= a <= 1.0");

            var probabilityA = Decimal.Parse(Console.ReadLine());

            _logger.Information("Please enter the second valid probability(0.0 >= b <= 1.0");

            var probabilityB = Decimal.Parse(Console.ReadLine());

            _logger.Information("Which calculation would you like to perform?");
            _logger.Information("Press 1 for CombinedWith (P(A)P(B) e.g. 0.5 * 0.5 = 0.25");
            _logger.Information("Press 2 for Either P(A) + P(B) - P(A)P(B) e.g. 0.5 + 0.5 – 0.5 * 0.5 = 0.75");

            var calculationChosen = int.Parse(Console.ReadLine());
            decimal result = 0m;
            if (calculationChosen == 1)
                result = _calculatorService.CalculateProbabilities(probabilityA, probabilityB, CalculationType.CombinedWith);
            if (calculationChosen == 2)
                result = _calculatorService.CalculateProbabilities(probabilityA, probabilityB, CalculationType.Either);

            _logger.Debug($"Your result is: {result}");

            return result;
        }
    }
}