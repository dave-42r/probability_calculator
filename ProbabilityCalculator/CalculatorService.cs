using System;

namespace ProbabilityCalculator.UnitTests
{
    public class CalculatorService : ICalculatorService
    {
        public void CalculateProbabilities(in decimal probabilityA, in decimal probabilityB)
        {
            throw new ArgumentException();
        }
    }
}