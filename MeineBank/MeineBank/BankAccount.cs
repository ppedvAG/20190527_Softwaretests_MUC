using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeineBank
{
    public enum Wealth { Zero,Poor,Ok,Rich};

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
        public Wealth Wealth
        {
            get
            {
                if (Balance == 0)
                    return Wealth.Zero;
                else if (Balance < 100)
                    return Wealth.Poor;
                else if (Balance < 10000)
                    return Wealth.Ok; 
                else // alles drüber
                    return Wealth.Rich;
            }
        }

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
