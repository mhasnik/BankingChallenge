using System;

namespace BankingChallenge.Logic.Extensions
{
    public static class DoubleExtensions
    {
        public static decimal ToDecimalWithPrecision5(this double number)
        {
            const int precisionMultiplier = 100_000;
            return (decimal) Math.Round(number * precisionMultiplier, MidpointRounding.ToEven) /
                   precisionMultiplier;
        }
    }
}