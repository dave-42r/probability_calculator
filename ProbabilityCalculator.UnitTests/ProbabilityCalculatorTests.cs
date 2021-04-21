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

        [Test]
        public void At_least_Two_Types_Of_Calculation_Can_Be_Performed()
        {
            Assert.DoesNotThrow(() => _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB, CalculationType.CombinedWith));
            Assert.DoesNotThrow(() => _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB, CalculationType.Either));
        }

        [Test]
        public void CombinedWith_Calculation_Should_Multiply_Probabilities_Together()
        {
            //Given
            ProbabilityA = 0.5m;
            ProbabilityB = 0.5m;
            decimal expectedResult = 0.25m;

            //When
            decimal actualResult = _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB, CalculationType.CombinedWith);

            //Then
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Either_Calculation_Should_Add_Two_Probabilities_Then_Subtract_The_Same_Two_Combined()
        {
            //Given
            ProbabilityA = 0.5m;
            ProbabilityB = 0.5m;
            decimal expectedResult = 0.75m;

            //When
            decimal actualResult = _calculatorService.CalculateProbabilities(ProbabilityA, ProbabilityB, CalculationType.Either);

            //Then
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}