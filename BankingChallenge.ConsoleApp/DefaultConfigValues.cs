using BankingChallenge.Logic.Models;

namespace BankingChallenge.ConsoleApp
{
    // Normally would store this in appSettings.json, but I didn't want
    // to loose time enforcing fallback, when someone deletes that file
    class DefaultConfigValues
    {
        internal const decimal AdministrativeFeeMaxCap = 10_000;
        internal const decimal AdministrativeFeeRate = 1;
        internal const decimal AnnualInterestRate = 5;
        internal const PaymentInterval PaymentInterval = Logic.Models.PaymentInterval.Monthly;
    }
}
