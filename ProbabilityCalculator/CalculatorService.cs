using System;
using ProbabilityCalculator.UnitTests;

namespace ProbabilityCalculator
{
    public class CalculatorService : ICalculatorService
    {
        public decimal CalculateProbabilities(in decimal probabilityA, in decimal probabilityB, CalculationType calculationType)
        {
            ValidateUserInputs(probabilityA, probabilityB);

            if (calculationType == CalculationType.Either)
                return CalculateEither(probabilityA, probabilityB);

            if (calculationType == CalculationType.CombinedWith)
                return CalculateCombinedWith(probabilityA, probabilityB);

            throw new ArgumentException("This calculation type is not expected");
        }

        private static decimal CalculateEither(decimal probabilityA, decimal probabilityB)
        {
            return probabilityA + probabilityB - (CalculateCombinedWith(probabilityA, probabilityB));
        }

        private static decimal CalculateCombinedWith(decimal probabilityA, decimal probabilityB)
        {
            return probabilityA * probabilityB;
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