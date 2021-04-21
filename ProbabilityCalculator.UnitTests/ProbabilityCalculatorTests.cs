using System;
using NUnit.Framework;

namespace ProbabilityCalculator.UnitTests
{
    public class ProbabilityCalculatorTests
    {
        private ICalculatorService _calculatorService;
        public decimal ProbabilityA { get; set; }
        public decimal ProbabilityB { get; set; }

        [SetUp]
        public void Setup()
        {
            _calculatorService = new CalculatorService();
            ProbabilityA = 0;
            ProbabilityB = 1;
        }

        [Test]
        public void The_Calculator_Should_Take_Two_Valid_Probabilities()
        {
            ProbabilityA = -1m;
            ProbabilityB = 1.1m;
            Assert.Throws<ArgumentException>(() => _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB));
        }

        [Test]
        public void The_Calculator_Should_Validate_Both_Inputs_Are_Valid_Independently()
        {
            ProbabilityB = 1.1m;
            Assert.Throws<ArgumentException>(() => _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB));

            ProbabilityB = 0m;
            ProbabilityA = 1.1m;
            Assert.Throws<ArgumentException>(() => _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB));
        }
    }

    public class CalculatorService : ICalculatorService
    {
        public void CalculateProbabilities(in decimal probabilityA, in decimal probabilityB)
        {
            throw new ArgumentException();
        }
    }

    public interface ICalculatorService
    {
        void CalculateProbabilities(in decimal probabilityA, in decimal probabilityB);
    }
}