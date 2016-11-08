using System;
using System.Numerics;

namespace BigNumbersMVC.Helpers
{
    public static class BigNumbersHelper
    {
        public static string Sum(string number1, string number2)
        {
            if (number1 == null)
                throw new ArgumentNullException(nameof(number1));
            if (number2 == null)
                throw new ArgumentNullException(nameof(number2));
            BigInteger bigInteger1;
            BigInteger bigInteger2;
            if (!BigInteger.TryParse(number1, out bigInteger1))
                throw new ArgumentException($"{nameof(number1)} is not a number");
            if (!BigInteger.TryParse(number2, out bigInteger2))
                throw new ArgumentException($"{nameof(number2)} is not a number");

            return (bigInteger1 + bigInteger2).ToString();
        }
    }
}