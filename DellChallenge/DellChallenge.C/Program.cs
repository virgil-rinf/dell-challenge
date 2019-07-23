using System;
using System.Linq;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            StartHere();
            Console.ReadKey();
        }

        private static void StartHere()
        {
            int sum1 = Calculator.Add(1, 3);
            int sum2 = Calculator.Add(1, 3, 5);
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
        }
    }


    // it makes more sense for this class to be static in the actual context since it's not justified to be able to creeate multiple instances of calculator and it does not need to retain any information
    // If in the requirments there would be diferent types of calculators than a non-static approach would make more sense
    public static class Calculator
    {
        public static int Add(params int[] values)
        {
            if (values == null || !values.Any())
            {
                return 0;
            }
            return values.Sum();
        }
    }
}
