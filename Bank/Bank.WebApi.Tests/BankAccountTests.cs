using Bank.WebApi.Models;
using NUnit.Framework;
using System;

namespace Bank.Domain.Tests
{
    public class BankAccountTests
    {
        // Test for Debit method with valid amount
        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 100;
            double debitAmount = 50;
            double expectedBalance = 50;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(expectedBalance), "Balance should be updated correctly after a valid debit.");
        }

        // Test for Debit method with amount greater than balance
        [Test]
        public void Debit_WithAmountGreaterThanBalance_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 100;
            double debitAmount = 150;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount), "Should throw an exception if debit amount is greater than balance.");
        }

        // Test for Debit method with negative amount
        [Test]
        public void Debit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 100;
            double debitAmount = -10;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount), "Should throw an exception if debit amount is negative.");
        }

        // Test for Debit method that brings balance to exactly zero
        [Test]
        public void Debit_WithAmountEqualToBalance_UpdatesBalanceToZero()
        {
            // Arrange
            double beginningBalance = 100;
            double debitAmount = 100;
            double expectedBalance = 0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(expectedBalance), "Balance should be zero after debiting an amount equal to the balance.");
        }

        // Test for Credit method with small fractional amount
        [Test]
        public void Credit_WithSmallFractionalAmount_UpdatesBalanceCorrectly()
        {
            // Arrange
            double beginningBalance = 100;
            double creditAmount = 0.75;
            double expectedBalance = 100.75;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(expectedBalance), "Balance should be updated correctly with a small fractional credit.");
        }

        // Test to ensure that the constructor initializes correctly
        [Test]
        public void Constructor_InitializesBalanceAndCustomerNameCorrectly()
        {
            // Arrange
            string customerName = "Mr. Bryan Walton";
            double initialBalance = 200;

            // Act
            BankAccount account = new BankAccount(customerName, initialBalance);

            // Assert
            Assert.That(account.CustomerName, Is.EqualTo(customerName), "Customer name should be initialized correctly.");
            Assert.That(account.Balance, Is.EqualTo(initialBalance), "Initial balance should be set correctly.");
        }

        // Test to verify balance remains the same after a debit and credit of the same amount
        [Test]
        public void DebitAndCredit_WithSameAmount_LeavesBalanceUnchanged()
        {
            // Arrange
            double beginningBalance = 100;
            double amount = 50;
            double expectedBalance = 100;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(amount);
            account.Credit(amount);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(expectedBalance), "Balance should remain the same after debiting and crediting the same amount.");
        }
        // Test for Credit method with negative amount
        [Test]
        public void Credit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 100;
            double creditAmount = -10;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(creditAmount), "Should throw an exception if credit amount is negative.");
        }

        // Test for multiple debit transactions
        [Test]
        public void Debit_MultipleValidAmounts_UpdatesBalanceCorrectly()
        {
            // Arrange
            double beginningBalance = 200;
            double firstDebit = 50;
            double secondDebit = 30;
            double expectedBalance = 120;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(firstDebit);
            account.Debit(secondDebit);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(expectedBalance), "Balance should be updated correctly after multiple debits.");
        }

        // Test for Credit method with a very large amount
        [Test]
        public void Credit_WithLargeAmount_UpdatesBalanceCorrectly()
        {
            // Arrange
            double beginningBalance = 100;
            double largeCreditAmount = 1_000_000;
            double expectedBalance = 1_000_100;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(largeCreditAmount);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(expectedBalance), "Balance should be updated correctly after a large credit.");
        }

        // Test for constructor with zero initial balance
        [Test]
        public void Constructor_InitializesWithZeroBalanceCorrectly()
        {
            // Arrange
            string customerName = "Mr. Bryan Walton";
            double initialBalance = 0;

            // Act
            BankAccount account = new BankAccount(customerName, initialBalance);

            // Assert
            Assert.That(account.CustomerName, Is.EqualTo(customerName), "Customer name should be initialized correctly.");
            Assert.That(account.Balance, Is.EqualTo(initialBalance), "Initial balance should be set to zero.");
        }
    }
}
