using System.CommandLine;

namespace BankingChallenge.ConsoleApp.Arguments
{
    class LoanDurationInYearsOption : Option<int>
    {
        public LoanDurationInYearsOption()
            : base(
                new[] {"--loan-duration-in-years", "-d"},
                "Duration of loan provided in years"
            )
        {
            IsRequired = true;
        }
    }
}