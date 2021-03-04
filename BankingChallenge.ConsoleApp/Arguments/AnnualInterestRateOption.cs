using System.CommandLine;

namespace BankingChallenge.ConsoleApp.Arguments
{
    class AnnualInterestRateOption : Option<decimal>
    {
        public AnnualInterestRateOption()
            : base(
                new[] {"--annual-interest-rate", "-r"},
                () => DefaultValues.AnnualInterestRate,
                "Loan annual interest rate in percent"
            )
        { }
    }
}