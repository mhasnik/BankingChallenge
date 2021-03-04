using System;

namespace BankingChallenge.Logic.Models
{
    public class LoanTerms
    {
        public Percent AnnualInterestRate { get; }
        public PaymentInterval PaymentInterval { get; }
        public double PaymentsInYear { get; }
        public Percent AdministrativeFeeRate { get; }
        public Money AdministrativeFeeMaxCap { get; }

        public LoanTerms(Percent annualInterestRate,
            PaymentInterval paymentInterval,
            Percent administrativeFeeRate,
            Money administrativeFeeMaxCap
        )
        {
            AnnualInterestRate = annualInterestRate;
            PaymentInterval = paymentInterval;
            AdministrativeFeeRate = administrativeFeeRate;
            AdministrativeFeeMaxCap = administrativeFeeMaxCap;
            PaymentsInYear = PaymentInterval switch
            {
                // Estimated values, exact handling depends on domain
                PaymentInterval.Daily => 365.242199,
                PaymentInterval.Weekly => 52.177457,
                // Exact values
                PaymentInterval.Monthly => 12,
                PaymentInterval.Quarterly => 4,
                PaymentInterval.SemiAnnually => 2,
                PaymentInterval.Annually => 1,
                _ => throw new ArgumentOutOfRangeException(
                    nameof(paymentInterval),
                    "Invalid calculation interval value"
                )
            };
        }
    }
}