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
    public class MakingDepositTests
    {
        [Fact]
        public void DepositIncreasesBalance()
        {
            var account = new BankAccount(new Mock<ICalculateDepositBonusesForAccounts>().Object);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }
    }


}