using BankingChallenge.Logic.Models;
using Xunit;

namespace BankingChallenge.Logic.Tests
{
    public class LoanCalculationsTests
    {
        [Fact]
        public void Should_Return_Should_Return_Accurate_Single_Payment_On_Data_From_Home_Assignment()
        {
            var sut = new LoanCalculations();

            var actualResult = sut.CalculateSinglePayment(
                500_000m,
                new Percent(5),
                12,
                120
            );

            Assert.Equal(5303.27576m, actualResult);
        }

        [Fact]
        public void Should_Return_Accurate_Total_Payment_On_Data_From_Home_Assignment()
        {
            var sut = new LoanCalculations();

            var actualResult = sut.CalculateTotalPayment(
                5303.27576m,
                120
            );

            Assert.Equal(636_393.09120m, actualResult);
        }

        [Fact]
        public void Should_Return_Accurate_Total_Interest_On_Data_From_Home_Assignment()
        {
            var sut = new LoanCalculations();

            var actualResult = sut.CalculateTotalInterest(
                636_393.09120m,
                500_000m
            );

            Assert.Equal(136_393.09120m, actualResult);
        }

        [Fact]
        public void Should_Return_Accurate_Administrative_Fee_On_Data_From_Home_Assignment()
        {
            var sut = new LoanCalculations();

            var actualResult = sut.CalculateAdministrativeFee(
                500_000m,
                new Percent(1),
                new Money(10_000m)
            );

            Assert.Equal(5_000m, actualResult);
        }

        [Fact]
        public void Should_Return_Accurate_AOP()
        {
            var sut = new LoanCalculations();

            var actualResult = sut.CalculateAop(
                636393.091434439920m,
                5000m,
                500_000m,
                10
            );

            Assert.Equal(2.8278618286887984m, actualResult);
        }
    }
}