using Bank.WebApi.Models;
using NUnit.Framework;

namespace Bank.Domain.Tests
{
    public class BankAccountTests
    {
        // ... (tus pruebas existentes)

        [Test]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // ... (tu prueba existente)
        }

        [Test]
        public void Credit_WithZeroAmount_DoesNotUpdateBalance()
        {
            // Arrange
            double beginningBalance = 100;
            double creditAmount = 0;
            double expected = 100;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Balance should not change with a zero credit");
        }

        [Test]
        public void Credit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 100;
            double creditAmount = -10;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }

        [Test]
        public void Credit_WithLargeAmount_UpdatesBalanceCorrectly()
        {
            // Arrange
            double beginningBalance = 100;
            double creditAmount = 1000000;
            double expected = 1000100;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Balance should be updated correctly with a large credit");
        }
    }
}