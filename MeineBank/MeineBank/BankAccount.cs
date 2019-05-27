using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeineBank
{
    public class BankAccount
    {
        private decimal v;

        public BankAccount()
        {
        }

        public BankAccount(decimal v)
        {
            this.v = v;
        }

        public decimal Balance { get; set; }

        public void Deposit(decimal v)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(decimal v)
        {
            throw new NotImplementedException();
        }
    }
}
