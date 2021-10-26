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
    public class NewAccountTests
    {
        [Fact]
        public void HaveCorrectStartingBalance()
        {
            // WTCYWYH
            // Given

            var account = new BankAccount(new Mock<ICalculateDepositBonusesForAccounts>().Object);

            // When
            decimal balance = account.GetBalance();

            // Then
            Assert.Equal(1000M, balance);

        }

        [Fact]
        public void GetBalanceDoesNotUseBonusCalculator()
        {
            // WTCYWYH
            // Given
            var dummyBonusCalculator = new Mock<ICalculateDepositBonusesForAccounts>();
            var account = new BankAccount(dummyBonusCalculator.Object);

            // When
            decimal balance = account.GetBalance();

            // Then

            dummyBonusCalculator.Verify(
                c => c.GetBonusFor(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
        }
    }
}