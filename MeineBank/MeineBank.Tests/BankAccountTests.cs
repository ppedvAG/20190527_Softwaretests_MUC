using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeineBank.Tests
{

    [TestClass]
    public class BankAccountTests
    {
        // Alles erst einmal herunterprogrammieren
        [TestMethod]
        public void BankAccount_new_account_has_zero_balance()
        {
            var ba = new BankAccount();

            Assert.AreEqual(decimal.Zero, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_new_account_gets_correct_balance_from_constructor()
        {
            var b1 = new BankAccount(0m);
            var b2 = new BankAccount(-20m);
            var b3 = new BankAccount(20m);

            Assert.AreEqual(0m, b1.Balance);
            Assert.AreEqual(-20m, b2.Balance);
            Assert.AreEqual(20m, b3.Balance);
        }

        [TestMethod]
        public void BankAccount_can_deposit()
        {
            var ba = new BankAccount();

            ba.Deposit(5m);
            Assert.AreEqual(5m, ba.Balance);

            ba.Deposit(3.3333m);
            Assert.AreEqual(8.3333m, ba.Balance);
        }

        // was passiert wenn der kunde 0m einzahlt ? gar nichts ? eine exception ?
        // was passiert wenn der kunde -5m einzahlt ?

        // Vorteil: wir sind noch in der "Planungsphase" und können genau diese Extremfälle sehr leicht in Form von Tests einbauen

        [TestMethod]
        public void BankAccount_deposit_negative_value_throws_ArgumentException()
        {
            var ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(-5m));
        }

        [TestMethod]
        public void BankAccount_can_withdraw()
        {
            var ba = new BankAccount(20m);

            ba.Withdraw(5m);
            Assert.AreEqual(15m, ba.Balance);

            ba.Withdraw(3m);
            Assert.AreEqual(12m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_withdraw_negative_value_throws_ArgumentException()
        {
            var ba = new BankAccount(20m);

            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(-5m));
        }

        [TestMethod]
        public void BankAccount_withdraw_over_balance_throws_ArgumentException()
        {
            var ba = new BankAccount(20m);

            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(20.0000001m));
        }

        // Zustand, den man einchecken kann

    }
}
