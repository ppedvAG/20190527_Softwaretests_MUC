using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeineBank
{
    public class BankAccount
    {
        public BankAccount()
        {
        }

        public BankAccount(decimal Balance)
        {
            this.Balance = Balance;
        }

        public decimal Balance { get; private set; }

        public void Deposit(decimal value)
        {
            if (value < 0)
                throw new ArgumentException();

            Balance += value;
        }

        public void Withdraw(decimal value)
        {
            if (value < 0 || value > Balance)
                throw new ArgumentException();
            Balance -= value;
        }
    }
}
