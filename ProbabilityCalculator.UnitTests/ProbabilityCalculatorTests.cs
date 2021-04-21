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
        public void Given_Two_Invalid_Inputs_The_Calculator_Should_Throw_An_ArgumentException()
        {
            ProbabilityA = -1m;
            ProbabilityB = 1.1m;
            Assert.Throws<ArgumentException>(() => _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB));
        }

        [Test]
        public void Given_Two_Valid_Inputs_The_Calculator_Should_Not_Throw_An_ArgumentException()
        {
            ProbabilityA = 0m;
            ProbabilityB = 1m;
            Assert.DoesNotThrow(() => _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB));
        }

        [Test]
        public void
            Given_Probability_A_Is_Greater_Than_1_When_Calculating_Probabilities_Then_An_ArgumentException_Should_Be_Thrown()
        {
            ProbabilityA = 1.1m;
            Assert.Throws<ArgumentException>(
                () => _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB));
        }

        [Test]
        public void Given_Probability_A_Is_Less_Than_0_When_Calculating_Probabilities_Then_An_ArgumentException_Should_Be_Thrown()
        {
            ProbabilityA = -1.1m;
            Assert.Throws<ArgumentException>(() => _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB));
        }

        [Test]
        public void Given_Probability_B_Is_Less_Than_0_When_Calculating_Probabilities_Then_An_ArgumentException_Should_Be_Thrown() {
            ProbabilityB = -1.1m;
            Assert.Throws<ArgumentException>(() => _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB));
        }

        [Test]
        public void Given_Probability_B_Is_Greater_Than_1_When_Calculating_Probabilities_Then_An_ArgumentException_Should_Be_Thrown()
        {
            ProbabilityB = 1.1m;
            Assert.Throws<ArgumentException>(() => _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB));
        }
    }
}