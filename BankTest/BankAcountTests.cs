using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest
{
    [TestClass]
    public class BankAcountTests
    {
        
        [TestMethod]
        public void Debit_withValidAmount_UpdateBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("muri", beginningBalance);
            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Débito não ocorreu corretamente.");
        }
        
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -11.00;
            BankAccount account = new BankAccount("Murilo", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.00;
            BankAccount account = new BankAccount("Murilo", beginningBalance);

            // Act
            // captura a exceção que é esperada e verifica a mensagem esperada
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void Credit_WithValidAmount_UpdateBalance()
        {
            // Arrange
            double beginningBalance = 10.00;
            double creditAmount = 5.00;
            double expected = 15.00;
            BankAccount account = new BankAccount("muri", beginningBalance);
            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "O credito não ocorreu corretamente.");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessOrEqualThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.00;
            double creditAmount = -10.00;
            BankAccount account = new BankAccount("Murilo", beginningBalance);

            // Act
            try
            {
                account.Credit(creditAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessOrEqualThanZeroMessege);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
