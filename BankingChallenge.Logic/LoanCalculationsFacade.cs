using BankingChallenge.Logic.Models;

namespace BankingChallenge.Logic
{
    public class LoanCalculationsFacade
    {
        private readonly LoanCalculations _loanCalculations;

        public LoanCalculationsFacade()
        {
            // No DI on purpose
            // It is facade responsibility to create its dependencies and encapsulate class library internals
            _loanCalculations = new LoanCalculations();
        }

        public PaymentOverview CalculatePaymentOverview(LoanParameters parameters, LoanTerms terms)
        {
            var totalNumberOfPayments = parameters.DurationInYears * terms.PaymentsInYear;

            var administrativeFee = _loanCalculations.CalculateAdministrativeFee(
                parameters.MoneyToLoan.Amount,
                terms.AdministrativeFeeRate,
                terms.AdministrativeFeeMaxCap
            );

            var singlePayment = _loanCalculations.CalculateSinglePayment(
                parameters.MoneyToLoan.Amount,
                terms.AnnualInterestRate,
                terms.PaymentsInYear, totalNumberOfPayments
            );

            var totalPayment = _loanCalculations.CalculateTotalPayment(
                singlePayment,
                totalNumberOfPayments
            );

            var totalInterest = _loanCalculations.CalculateTotalInterest(
                totalPayment,
                parameters.MoneyToLoan.Amount
            );

            var aop = _loanCalculations.CalculateAop(
                totalPayment,
                administrativeFee,
                parameters.MoneyToLoan.Amount,
                parameters.DurationInYears
            );

            return new PaymentOverview(
                new Money(singlePayment),
                new Money(totalPayment),
                new Money(totalInterest),
                new Money(administrativeFee),
                new Percent(aop),
                parameters,
                terms
            );
        }
    }
}