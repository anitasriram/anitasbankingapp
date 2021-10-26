namespace BankingDomain
{
    public interface ICalculateDepositBonusesForAccounts
    {
        decimal GetBonusFor(decimal balance, decimal amountOfDeposit);
    }
}