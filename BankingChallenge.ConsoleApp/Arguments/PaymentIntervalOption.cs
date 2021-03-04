using System.CommandLine;
using BankingChallenge.Logic.Models;

namespace BankingChallenge.ConsoleApp.Arguments
{
    class PaymentIntervalOption : Option<PaymentInterval>
    {
        public PaymentIntervalOption()
            : base(
                new[] {"--payment-interval", "-i"},
                () => DefaultValues.PaymentInterval,
                "Intervals between single payments"
            )
        { }
    }
}