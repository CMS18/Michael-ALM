using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Uppg_01.Models.Entities
{
    public static class BankRepository
    {
        public static string ErrorMessage = "";
        public static string SuccessMessage = "";

        public const string CantAccessNonExistingAccount = "There is no account with that Id";

        private static List<Customer> Customers { get; set; }
        public static List<Customer> GetCustomers()
        {
            return Customers;
        }
        public static void AddCustomers(List<Customer> customers)
        {
            Customers = customers;
        }

        public static List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            for (int i = 0; i < Customers.Count; i++)
            {
                accounts.AddRange(Customers[i].Accounts);
            }
            return accounts;
        }

        public static Account Withdrawal(int accountId, decimal amount)
        {
            var account = GetAccount(accountId);

            if (amount < 0)
            {
                ErrorMessage = "You can't widthdraw negative amounts";
            }
            else
            {
                if (account != null)
                {
                    if (amount <= account.Balance)
                    {
                        account.Balance -= amount;
                        SuccessMessage = $"You successfully withdrew {amount} SEK from account {accountId}. Current balance: {account.Balance} SEK.";
                        ErrorMessage = "";
                    }
                    else
                    {
                        SuccessMessage = "";
                        ErrorMessage = "You can't widthdraw more than the balance of the account.";
                    }
                }
                else
                {
                    SuccessMessage = "";
                    ErrorMessage = CantAccessNonExistingAccount;
                }
            }

            return account;
        }

        public static Account Deposit(int accountId, decimal amount)
        {
            var account = GetAccount(accountId);

            if (account != null)
            {
                if (amount < 0)
                {
                    SuccessMessage = "";
                    ErrorMessage = "You can't deposit negative amounts.";
                }
                else
                {
                    account.Balance += amount;
                    SuccessMessage = $"You successfully deposited {amount} SEK to account {accountId}. Current balance: {account.Balance} SEK.";
                    ErrorMessage = "";
                }
            }
            else
            {
                SuccessMessage = "";
                ErrorMessage = CantAccessNonExistingAccount;
            }

            return account;
        }

        private static Account GetAccount(int accountId)
        {
            var account = GetAccounts().Find(a => a.AccountId == accountId);
            return account;
        }

        public static bool Transfer(decimal amount, int fromAccountId, int toAccountId)
        {

            var accountTo = GetAccount(toAccountId);
            var accountFrom = GetAccount(fromAccountId);
            if (accountFrom == null || accountTo == null)
            {
                ErrorMessage = "The account could not be found. Make sure both account numbers are correct.";
                SuccessMessage = "";
            }
            else
            {
                if (accountFrom.Balance - amount < 0)
                {
                    ErrorMessage =
                        $"The amount you're transferring can't be higher than your balance. Your current balance is {accountFrom.Balance}";
                    SuccessMessage = "";
                }
                else
                {
                    if (accountFrom.AccountId == accountTo.AccountId)
                    {
                        ErrorMessage =
                            "The account you're sending money to can't be the same account you're deducting money from.";
                        SuccessMessage = "";
                    }
                    else
                    {
                        if (amount < 0)
                        {
                            ErrorMessage = $"You can't transfer negative amount of {amount} from {accountFrom.AccountId} to {accountTo.AccountId}";
                            SuccessMessage = "";
                        }
                        else
                        {
                            accountFrom.Balance -= amount;
                            accountTo.Balance += amount;
                            ErrorMessage = "";
                            SuccessMessage =
                                $"Congratulations you've transferred {amount} to account # {accountTo.AccountId} and the new balance is {accountTo.Balance}";
                        }
                    }
                }
            }

            return true;
        }
    }
}

//if (accountFrom == null || accountFrom.Balance - amount< 0 || accountTo == null || accountFrom.AccountId == accountTo.AccountId)
//{
//ErrorMessage = "Something went wrong. Make sure that you've entered the correct information.";
//SuccessMessage = "";
//}
//else
//{
//accountFrom.Balance -= amount;
//accountTo.Balance += amount;
//ErrorMessage = "";
//SuccessMessage = $"Congratulations you've transferred {amount} to account # {accountTo.AccountId} and the new balance is {accountTo.Balance}";
//}
