using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 1000;
        private readonly ICalculateDepositBonusesForAccounts _bonusCalculator;

        public BankAccount(ICalculateDepositBonusesForAccounts bonusCalculator)
        {
            _bonusCalculator = bonusCalculator;
        }

        public decimal GetBalance()
        {
            return _balance;
        }
      

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _balance)
            {
                throw new OverdraftException();
            }
            else
            {
                _balance -= amountToWithdraw;
            }
        }

        public void Deposit(decimal amountToDeposit)
        {
            var amountOfBonus = _bonusCalculator.GetBonusFor(_balance, amountToDeposit);
            _balance += amountToDeposit + amountOfBonus;
        }
    }
}