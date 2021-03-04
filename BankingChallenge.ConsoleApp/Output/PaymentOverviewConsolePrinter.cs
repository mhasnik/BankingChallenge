using System.CommandLine;
using System.CommandLine.IO;
using BankingChallenge.Logic.Models;

namespace BankingChallenge.ConsoleApp.Output
{
    class PaymentOverviewConsolePrinter
    {
        private static readonly string ReportHeaderSeparator = new('*', 10);
        private static readonly string ReportSectionSeparator = new('-', 5);

        public void Print(PaymentOverview overview, IConsole console)
        {
            console.Out.WriteLine(ReportHeaderSeparator);
            console.Out.WriteLine("Payment Overview");
            console.Out.WriteLine(ReportHeaderSeparator);

            console.Out.WriteLine(ReportSectionSeparator);
            console.Out.WriteLine("Based on following input:");
            console.Out.WriteLine(ReportSectionSeparator);

            console.Out.WriteLine($"{nameof(overview.Parameters.MoneyToLoan)} : {overview.Parameters.MoneyToLoan}");
            console.Out.WriteLine($"{nameof(overview.Parameters.DurationInYears)} : {overview.Parameters.DurationInYears}");
            console.Out.WriteLine($"{nameof(overview.Terms.AnnualInterestRate)} : {overview.Terms.AnnualInterestRate}");
            console.Out.WriteLine($"{nameof(overview.Terms.AdministrativeFeeMaxCap)} : {overview.Terms.AdministrativeFeeMaxCap}");
            console.Out.WriteLine($"{nameof(overview.Terms.AdministrativeFeeRate)} : {overview.Terms.AdministrativeFeeRate}");
            console.Out.WriteLine($"{nameof(overview.Terms.PaymentInterval)} : {overview.Terms.PaymentInterval}");

            console.Out.WriteLine(ReportSectionSeparator);
            console.Out.WriteLine("Generated following overview:");
            console.Out.WriteLine(ReportSectionSeparator);

            console.Out.WriteLine($"{nameof(overview.SinglePayment)} : {overview.SinglePayment}");
            console.Out.WriteLine($"{nameof(overview.TotalPayment)} : {overview.TotalPayment}");
            console.Out.WriteLine($"{nameof(overview.TotalInterestRate)} : {overview.TotalInterestRate}");
            console.Out.WriteLine($"{nameof(overview.TotalAdministrativeFees)} : {overview.TotalAdministrativeFees}");
            console.Out.WriteLine($"{nameof(overview.Aop)} : {overview.Aop}");
        }
    }
}