using System.CommandLine;
using BankingChallenge.Logic.Models;

namespace BankingChallenge.ConsoleApp.Arguments
{
    class PaymentIntervalOption : Option<PaymentInterval>
    {
        public PaymentIntervalOption()
            : base(
                new[] {"--payment-interval", "-i"},
                () => DefaultConfigValues.PaymentInterval,
                "Intervals between single payments"
            )
        { }
    }
}