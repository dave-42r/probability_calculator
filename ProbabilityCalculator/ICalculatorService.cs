namespace ProbabilityCalculator.UnitTests
{
    public interface ICalculatorService
    {
        decimal CalculateProbabilities(in decimal probabilityA, in decimal probabilityB, CalculationType calculationType = CalculationType.CombinedWith);
    }
}