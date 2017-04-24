using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class minBalException : Exception
    {
        public minBalException(string message) : base(message) { }
    }

    class MaxwithdrawalAmount : Exception
    {
        public MaxwithdrawalAmount(string message) : base(message) { }
    }
    class MaxDepositAmtException : Exception
    {
        public MaxDepositAmtException(string message) : base(message) { }
    }
    class AccountCloseException : Exception
    {
        public AccountCloseException(string message) : base(message) { }
    }
}
