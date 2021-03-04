using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using BankingChallenge.ConsoleApp.Arguments;
using BankingChallenge.ConsoleApp.Models;
using BankingChallenge.ConsoleApp.Output;
using BankingChallenge.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankingChallenge.ConsoleApp
{
    class Program
    {
        // A few words to a person that will evaluate this home assignment.
        // I did this in only one evening so the solution is far from perfect
        // I'm aware exception handling and CLI argument validation
        // are almost non-existent, but I wanted to focus on what I perceived
        // as the most crucial. If you'd like to talk about what can be improved
        // I'm happy to elaborate during a call.

        static async Task Main(string[] args)
        {
            await BuildCommandLine()
                // Using generic host for additional functionality out of the box
                .UseHost(_ => Host.CreateDefaultBuilder(),
                    host =>
                    {
                        host.ConfigureServices(services =>
                        {
                            services.AddTransient<PaymentOverviewConsolePrinter>();
                            services.AddTransient<LoanCalculationsFacade>();
                        });
                    })
                .UseDefaults()
                .Build()
                .InvokeAsync(args);
        }

        private static CommandLineBuilder BuildCommandLine()
        {
            var rootCommand = new RootCommand()
            {
                new LoanAmountOption(),
                new LoanDurationInYearsOption(),
                new AnnualInterestRateOption(),
                new PaymentIntervalOption(),
                new AdministrativeFeeRateOption(),
                new AdministrativeFeeMaxCapOption()
            };

            rootCommand.Description = "Simplified loan calculation";
            rootCommand.Handler = CommandHandler.Create<
                InputParameters,
                PaymentOverviewConsolePrinter,
                LoanCalculationsFacade,
                IConsole
            >(Run);

            return new CommandLineBuilder(rootCommand);
        }

        private static void Run(
            InputParameters inputParameters,
            PaymentOverviewConsolePrinter printer,
            LoanCalculationsFacade facade,
            IConsole console
        )
        {
            var paymentOverview = facade.CalculatePaymentOverview(
                inputParameters.ToLoanParameters(),
                inputParameters.ToLoanTerms()
            );

            printer.Print(paymentOverview, console);
        }
    }
}