using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests.BonusCalculator
{
    public class BonusCalculatorTests
    {

        private readonly StandardBonusCalculator bonusCalculator;

        public BonusCalculatorTests()
        {
            var stubbedClock = new Mock<IProvideTheBusinessClock>();
            stubbedClock.Setup(c => c.OutsideBusinessHours()).Returns(false);
            bonusCalculator = new StandardBonusCalculator(stubbedClock.Object);
        }

        
        [Theory]
        [InlineData(5000, 100, 10)]
        [InlineData(6000, 200, 20)]
        public void GoldAccountsMeetingTheLimitGetABonus(
            decimal balance,
            decimal amountOfDeposit,
            decimal expectedBonus)
        {
            

            decimal amountOfBonus = bonusCalculator.GetBonusFor(
                balance,
                amountOfDeposit);

            Assert.Equal(expectedBonus, amountOfBonus);
        }



        [Theory]
        [InlineData(1000, 100, 5)]
        [InlineData(4999.99, 100, 5)]
        public void SilverAccountsGetBonus(
     decimal balance,
     decimal amountOfDeposit,
     decimal expectedBonus)
        {
            

            decimal amountOfBonus = bonusCalculator.GetBonusFor(
                balance,
                amountOfDeposit);

            Assert.Equal(expectedBonus, amountOfBonus);
        }

        [Theory]
        [InlineData(999.99, 100, 0)]
        [InlineData(0, 100, 0)]
        public void StandardAccountsGetNoBonus(
decimal balance,
decimal amountOfDeposit,
decimal expectedBonus)
        {
            

            decimal amountOfBonus = bonusCalculator.GetBonusFor(
                balance,
                amountOfDeposit);

            Assert.Equal(expectedBonus, amountOfBonus);
        }
    }
}