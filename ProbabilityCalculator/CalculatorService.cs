using System;

namespace ProbabilityCalculator.UnitTests
{
    public class CalculatorService : ICalculatorService
    {
        public void CalculateProbabilities(in decimal probabilityA, in decimal probabilityB)
        {
            ValidateUserInputs(probabilityA, probabilityB);
        }

        private static void ValidateUserInputs(decimal probabilityA, decimal probabilityB)
        {
            if (probabilityA > 1m || probabilityA < 0m)
                throw new ArgumentException();
            if (probabilityB > 1m || probabilityB < 0m)
                throw new ArgumentException();
        }
    }
}