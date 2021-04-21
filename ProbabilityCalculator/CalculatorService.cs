using System;

namespace ProbabilityCalculator.UnitTests
{
    public class CalculatorService : ICalculatorService
    {
        public decimal CalculateProbabilities(in decimal probabilityA, in decimal probabilityB, CalculationType calculationType)
        {
            ValidateUserInputs(probabilityA, probabilityB);

            return 0m;
        }

        private static void ValidateUserInputs(decimal probabilityA, decimal probabilityB, CalculationType calculationType = CalculationType.CombinedWith)
        {
            if (probabilityA > 1m || probabilityA < 0m)
                throw new ArgumentException();
            if (probabilityB > 1m || probabilityB < 0m)
                throw new ArgumentException();
        }
    }
}