using NUnit.Framework;

namespace ProbabilityCalculator.UnitTests
{
    public class ProbabilityCalculatorTests
    {
        public decimal ProbabilityA { get; set; }
        public decimal ProbabilityB { get; set; }
        [SetUp]
        public void Setup()
        {
            ProbabilityA = 0;
            ProbabilityB = 1;
        }

        [Test]
        public void The_Calculator_Should_Take_Two_Valid_Probabilities()
        {
            ProbabilityA = -1m;
            ProbabilityB = 1.1m;
            Assert.Throws(InvalidInputException);
        }

        [Test]
        public void The_Calculator_Should_Take_Two_Valid_Inputs()
        {
            Assert.Fail();
        }
    }
}