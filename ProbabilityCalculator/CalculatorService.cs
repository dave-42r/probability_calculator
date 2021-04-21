using System;

namespace ProbabilityCalculator.UnitTests
{
    public class CalculatorService : ICalculatorService
    {
        public decimal CalculateProbabilities(in decimal probabilityA, in decimal probabilityB, CalculationType calculationType)
        {
            ValidateUserInputs(probabilityA, probabilityB);

            if (calculationType == CalculationType.Either)
                return probabilityA + probabilityB - (probabilityA * probabilityB);

            if (calculationType == CalculationType.CombinedWith)
                return probabilityA * probabilityB;

            throw new ArgumentException("This calculation type is not expected");
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