using System.CommandLine;

namespace BankingChallenge.ConsoleApp.Arguments
{
    class LoanAmountOption : Option<decimal>
    {
        public LoanAmountOption()
            : base(
                new[] {"--loan-amount", "-a"},
                "Amount of money user wants to lend"
            )
        {
            IsRequired = true;
        }
    }
}