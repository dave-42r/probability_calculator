using System;
using ProbabilityCalculator.UnitTests;

namespace ProbabilityCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the Probability Calculator");
            Console.WriteLine("Please enter the first valid probability(0.0 >= a <= 1.0");

            var probabilityA = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the second valid probability(0.0 >= b <= 1.0");

            var probabilityB = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Which calculation would you like to perform?");
            Console.WriteLine("Press 1 for CombinedWith (P(A)P(B) e.g. 0.5 * 0.5 = 0.25");
            Console.WriteLine("Press 2 for Either P(A) + P(B) - P(A)P(B) e.g. 0.5 + 0.5 – 0.5 * 0.5 = 0.75");

            var calculationChosen = int.Parse(Console.ReadLine());
            decimal result = 0m;
            if (calculationChosen == 1)
                result = new CalculatorService().CalculateProbabilities(probabilityA, probabilityB, CalculationType.CombinedWith);
            if (calculationChosen == 2)
                result = new CalculatorService().CalculateProbabilities(probabilityA, probabilityB, CalculationType.Either);

            Console.WriteLine($"Your result is: {result}");
        }
    }
}
