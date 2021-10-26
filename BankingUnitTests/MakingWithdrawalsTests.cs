using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests
{
    public class MakingWithdrawalsTests
    {
        private readonly BankAccount _account;
        private readonly decimal _openingBalance;


        public MakingWithdrawalsTests()
        {
            _account = new BankAccount(null);
            _openingBalance = _account.GetBalance();
        }
        [Fact]
        public void MakingWithdrawalsDecreasesTheBalance()
        {
            // Given

            var amountToWithdraw = 100M;
            // When
            _account.Withdraw(amountToWithdraw);
            // Then
            Assert.Equal(_openingBalance - amountToWithdraw, _account.GetBalance());
        }

        [Fact]
        public void CanWithdrawTotalBalance()
        {


            _account.Withdraw(_openingBalance);

            Assert.Equal(0, _account.GetBalance());
        }

        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {

            try
            {
                _account.Withdraw(_openingBalance + 1);
            }
            catch (OverdraftException)
            {

                // I was expecting that...
            }
            // I still want to be sure the balance didn't go down.
            Assert.Equal(_openingBalance, _account.GetBalance());
        }

        [Fact]
        public void OverdraftThrowsOverdraftException()
        {

            Assert.Throws<OverdraftException>(
                () => _account.Withdraw(_openingBalance + 1)
                );


        }
    }
}