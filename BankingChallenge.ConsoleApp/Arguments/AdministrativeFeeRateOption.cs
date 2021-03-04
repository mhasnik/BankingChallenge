using System.CommandLine;

namespace BankingChallenge.ConsoleApp.Arguments
{
    class AdministrativeFeeRateOption : Option<decimal>
    {
        public AdministrativeFeeRateOption()
            : base(
                new[] {"--administrative-fee-rate", "-f"},
                () => DefaultValues.AdministrativeFeeRate,
                "Percent rate of administrative fee"
            )
        { }
    }
}