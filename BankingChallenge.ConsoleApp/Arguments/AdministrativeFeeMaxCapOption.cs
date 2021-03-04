using System.CommandLine;

namespace BankingChallenge.ConsoleApp.Arguments
{
    class AdministrativeFeeMaxCapOption : Option<decimal>
    {
        public AdministrativeFeeMaxCapOption()
            : base(
                new[] { "--administrative-fee-max-cap", "-c" },
                () => DefaultValues.AdministrativeFeeMaxCap,
                "Maximum limit of administrative fee"
            )
        { }
    }
}