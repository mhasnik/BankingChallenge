namespace BankingChallenge.Logic.Models
{
    public class LoanParameters
    {
        public Money MoneyToLoan { get; }
        public int DurationInYears { get; }

        public LoanParameters(Money moneyToLoan, int durationInYears)
        {
            MoneyToLoan = moneyToLoan;
            DurationInYears = durationInYears;
        }
    }
}