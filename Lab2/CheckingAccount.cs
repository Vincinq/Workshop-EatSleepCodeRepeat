using System;
namespace eu.sig.training.ch04.v1
{
    public class CheckingAccount
    {
        private int transferLimit = 100;

        public Transfer MakeTransfer(String counterAccount, Money amount)
        {
            // 1. Check withdrawal limit:
            if (amount.GreaterThan(this.transferLimit))
            {
                throw new BusinessException("Limit exceeded!");
            }

            // 2. Assuming result is 9-digit bank account number, validate 11-test:
            if (String.IsNullOrEmpty(counterAccount) || counterAccount.Length != 9)
            {
                throw new BusinessException("Account number is empty or not 9 digits!");
            }

            return MakeTransferWithAmountWithinLimit(counterAccount, amount);
        }

        private Transfer MakeTransferWithAmountWithinLimit(string counterAccount, Money amount)
        {
            int sum = Accounts.CalculateSum(counterAccount);
            if (sum % 11 == 0)
            {
                // 3. Look up counter account and make transfer object:
                CheckingAccount acct = Accounts.FindAcctByNumber(counterAccount);
                Transfer result = new Transfer(this, acct, amount);
                return result;
            }
            else
            {
                throw new BusinessException("Invalid account number!");
            }
        }
    }
}