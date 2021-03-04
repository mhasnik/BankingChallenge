namespace BankingChallenge.Logic.Models
{
    public record PaymentOverview(
        Money SinglePayment,
        Money TotalPayment,
        Money TotalInterestRate,
        Money TotalAdministrativeFees,
        Percent Aop,
        LoanParameters Parameters,
        LoanTerms Terms
    );
}