using ALM_Uppg_01.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void Withdrawal_CantWithdrawMoreThanBalance()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Hannibal",
                    Id = 1,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 1,
                            Balance = 400M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = 500M;
            decimal expected = 400M;

            // Act
            // customer id, account id, amount
            var actualAccount = BankRepository.Withdrawal(1, amount);

            // Assert
            Assert.Equal(expected, actualAccount.Balance, 2);
        }

        [Fact]
        public void Withdrawal_CantWidthdrawNegativeAmount()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Hannibal",
                    Id = 2,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 2,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = -500M;
            decimal expected = 600M;

            // Act
            var account = BankRepository.Withdrawal(2, amount);

            // Assert
            Assert.Equal(expected, account.Balance, 2);
        }
        
        [Fact]
        public void Withdrawal_CantMakeBasicWidthdrawal()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Hannibal",
                    Id = 3,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 3,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = 200M;
            decimal expected = 400M;

            // Act
            var account = BankRepository.Withdrawal(3, amount);

            // Assert
            Assert.Equal(expected, account.Balance, 2);
        }

        [Fact]
        public void Withdrawal_CantWithdrawFromNonExistingAccount()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Hannibal",
                    Id = 3,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 3,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = 200M;
            string expected = BankRepository.CantAccessNonExistingAccount;

            // Act
            BankRepository.Withdrawal(1, amount);

            // Assert
            Assert.Equal(expected, BankRepository.ErrorMessage);
        }


        [Fact]
        public void Deposit_CantMakeBasicDeposit()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Hannibal",
                    Id = 4,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 4,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = 200M;
            decimal expected = 800M;

            // Act
            var account = BankRepository.Deposit(4, amount);

            // Assert
            Assert.Equal(expected, account.Balance, 2);
        }

        [Fact]
        public void Deposit_CantDepositNegativeAmount()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Hannibal",
                    Id = 5,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 5,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = -200M;
            decimal expected = 600M;

            // Act
            var account = BankRepository.Deposit(5, amount);

            // Assert
            Assert.Equal(expected, account.Balance, 2);
        }

        [Fact]
        public void Deposit_CantDepositToNonExistingAccount()
        {
            // Arrange
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Hannibal",
                    Id = 3,
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            AccountId = 3,
                            Balance = 600M
                        }
                    }
                }
            };
            BankRepository.AddCustomers(customers);
            decimal amount = 200M;
            string expected = BankRepository.CantAccessNonExistingAccount;

            // Act
            BankRepository.Deposit(1, amount);

            // Assert
            Assert.Equal(expected, BankRepository.ErrorMessage);
        }
    }
}
