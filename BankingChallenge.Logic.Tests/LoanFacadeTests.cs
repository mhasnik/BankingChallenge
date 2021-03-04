using BankingChallenge.Logic.Models;
using Xunit;

namespace BankingChallenge.Logic.Tests
{
    public class LoanFacadeTests
    {
        [Fact]
        public void Should_Return_Accurate_Payment_Overview_On_Data_From_Home_Assignment()
        {
            var sut = new LoanCalculationsFacade();

            var givenParameters = new LoanParameters(new Money(500_000m), 10);

            var givenTerms = new LoanTerms(
                new Percent(5),
                PaymentInterval.Monthly,
                new Percent(1),
                new Money(10_000)
            );

            var expectedResult = new PaymentOverview(
                new Money(5_303.28m),
                new Money(636_393.09m),
                new Money(136_393.09m),
                new Money(5000m),
                new Percent(2.827861824m),
                givenParameters,
                givenTerms
            );

            var actualResult = sut.CalculatePaymentOverview(
                givenParameters,
                givenTerms
            );

            Assert.Equal(expectedResult, actualResult);
        }
    }
}