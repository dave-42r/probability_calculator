namespace ProbabilityCalculator.UnitTests
{
    public interface ICalculatorService
    {
        void CalculateProbabilities(in decimal probabilityA, in decimal probabilityB, CalculationType calculationType = CalculationType.CombinedWith);
    }
}