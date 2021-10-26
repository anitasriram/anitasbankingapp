using System;

namespace BankingDomain
{
    public class StandardBonusCalculator : ICalculateDepositBonusesForAccounts
    {

        private readonly IProvideTheBusinessClock _businessClock;

        public StandardBonusCalculator(IProvideTheBusinessClock businessClock)
        {
            _businessClock = businessClock;
        }

        public decimal GetBonusFor(decimal balance, decimal amountOfDeposit)
        {
            //WTCYWYH
            if(_businessClock.OutsideBusinessHours())
            {
                return 0;
            }
            if (balance >= 5000M)
            {
                return amountOfDeposit * .10M;
            }
            else if (balance >= 1000M & balance < 5000)
            {
                return amountOfDeposit * .05M;
            }
            else
            {
                return 0;
            }
        }
    }
}