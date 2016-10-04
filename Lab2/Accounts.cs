using System;

namespace eu.sig.training.ch04.v1
{
    public static class Accounts
    {

        public static CheckingAccount FindAcctByNumber(string number)
        {
            return new CheckingAccount();
        }

        public static int CalculateSum(string counterAccount)
        {
            int sum = 0;
            for (int i = 0; i < counterAccount.Length; i++)
            {
                sum = sum + (9 - i) * (int)Char.GetNumericValue(counterAccount[i]);
            }
            return sum;
        }
    }
}