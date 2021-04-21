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

        }
    }
}
