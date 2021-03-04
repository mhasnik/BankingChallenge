using BankingChallenge.Logic.Models;

namespace BankingChallenge.ConsoleApp.Models
{
    record InputParameters(
        decimal LoanAmount,
        int LoanDurationInYears,
        decimal AnnualInterestRate,
        PaymentInterval PaymentInterval,
        decimal AdministrativeFeeRate,
        decimal AdministrativeFeeMaxCap
    )
    {
        public LoanParameters ToLoanParameters()
        {
            return new(
                new Money(LoanAmount),
                LoanDurationInYears
            );
        }

        public LoanTerms ToLoanTerms()
        {
            return new(
                new Percent(AnnualInterestRate),
                PaymentInterval,
                new Percent(AdministrativeFeeRate),
                new Money(AdministrativeFeeMaxCap)
            );
        }
    }
}
