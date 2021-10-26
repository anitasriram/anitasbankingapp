using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests
{
    public class AccountInteractsWithBonusCalculatorTests
    {
        [Fact]
        public void DepositGivesBonusCalculatorBalanceAndAmountAndAppliesBonusToBalance()
        {
            // Given - Arrange
            var stubbedBonusCalculator = new Mock<ICalculateDepositBonusesForAccounts>();

            var account = new BankAccount(stubbedBonusCalculator.Object);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 92.32M;
            stubbedBonusCalculator.Setup(b =>
                b.GetBonusFor(openingBalance, amountToDeposit)).Returns(108);


            // Act
            account.Deposit(amountToDeposit);


            // Assert
            Assert.Equal(
                openingBalance +
                amountToDeposit +
                108,
                account.GetBalance()
                );


        }
    }

    public class StubbedBonusCalcualtor : ICalculateDepositBonusesForAccounts
    {
        public decimal GetBonusFor(decimal balance, decimal amountOfDeposit)
        {
            if (balance == 1000M && amountOfDeposit == 92.32M)
            {
                return 42;
            }
            else
            {
                return 0;
            }
        }
    }
}