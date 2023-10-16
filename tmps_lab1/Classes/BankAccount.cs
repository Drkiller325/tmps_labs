using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps_lab1.Classes
{
    public class BankAccount : IBankAccount
    {
        public string? Owner { get; set; }
        public double balance { get; set; }

        private int Lower_Limit = 0;

        public bool status { get; set; }

        


        public void Activate_Account()
        {
            status = true;
        }

        public object CheckStatus()
        {
            return status;
        }

        public object Create_Account(string Owner, double balance)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.Owner = Owner;
            bankAccount.balance = balance;
            return bankAccount;
        }

    }

    public class CreditAccount : BankAccount
    {

        private int Lower_Limit = -2000;
        
        public void Add_Intrest()
        {
            balance += balance * 0.002;

        }


        


    }


    public class GiftCardAccount : BankAccount
    {
        private int Lower_Limit = 0;


    }
    
}
