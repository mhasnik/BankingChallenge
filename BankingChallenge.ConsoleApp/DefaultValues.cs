using BankingChallenge.Logic.Models;

namespace BankingChallenge.ConsoleApp
{
    class DefaultValues
    {
        internal const decimal AdministrativeFeeMaxCap = 10_000;
        internal const decimal AdministrativeFeeRate = 1;
        internal const decimal AnnualInterestRate = 5;
        internal const PaymentInterval PaymentInterval = Logic.Models.PaymentInterval.Monthly;
    }
}
