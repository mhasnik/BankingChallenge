using System;
using BankingChallenge.Logic.Extensions;
using BankingChallenge.Logic.Models;

namespace BankingChallenge.Logic
{
    internal class LoanCalculations
    {
        internal decimal CalculateAdministrativeFee(
            decimal loanAmount,
            Percent administrativeFeeRate,
            Money administrativeFeeMaxCap
        )
        {
            var feeFromPercentRate = loanAmount * administrativeFeeRate.ToFraction();
            return Math.Min(feeFromPercentRate, administrativeFeeMaxCap.Amount);
        }

        internal decimal CalculateSinglePayment(
            decimal loanAmount,
            Percent annualInterestRate,
            double numberOfPaymentsPerYear,
            double totalNumberOfPayments
        )
        {
            if (annualInterestRate.Value == 0)
            {
                throw new DivideByZeroException($"{nameof(annualInterestRate)} value can't be equal to 0");
            }

            // Formula source
            // http://www.math.hawaii.edu/~hile/math100/consf.htm

            // Using double on purpose, will lose some precision anyways
            // https://stackoverflow.com/a/6426826/4592601

            var periodicInterestRateAsFraction = (double) annualInterestRate.ToFraction() / numberOfPaymentsPerYear;
            var periodicInterestRateCompound = Math.Pow(1 + periodicInterestRateAsFraction, totalNumberOfPayments);

            var singlePayment = (double) loanAmount
                                * periodicInterestRateAsFraction
                                * periodicInterestRateCompound
                                / (periodicInterestRateCompound - 1);

            return singlePayment.ToDecimalWithPrecision5();
        }

        internal decimal CalculateTotalPayment(
            decimal singlePayment,
            double totalNumberOfPayments
        )
        {
            return singlePayment * (decimal) totalNumberOfPayments;
        }


        internal decimal CalculateTotalInterest(
            decimal totalPayments,
            decimal loanAmount
        )
        {
            return totalPayments - loanAmount;
        }

        internal decimal CalculateAop(
            decimal totalPayments,
            decimal administrativeFee,
            decimal loanAmount,
            int loanDurationInYears
        )
        {
            // I'm not really sure it's the right formula to calculate this metric
            // In the real world I'd ask someone with domain knowledge how should I calculate AOP

            var annualLoanFee = (totalPayments - loanAmount + administrativeFee) / loanDurationInYears;
            return annualLoanFee * 100 / loanAmount;
        }
    }
}