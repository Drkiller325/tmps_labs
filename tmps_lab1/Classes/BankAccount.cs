using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps_lab1.Classes
{
    public class BankAccount : IBankAccount
    {
        public string? Owner { get; set; }
        public double balance { get; set; }

        public int Lower_Limit = 0;

        public bool status { get; set; }

        public double comission = 0.002;

        public BankAccount(string owner, double balance) 
        {
            this.Owner = owner;
            this.balance = balance;
            this.status = false;
        }
        


        public void Activate_Account()
        {
            status = true;
        }

        public object CheckStatus()
        {
            return status;
        }

        public BankAccount Create_Account(string Owner, double balance,string type)
        {
            switch (type)
            {
                case "A":
                    return new BankAccount(Owner, balance);

                case "C":
                    return new CreditAccount(Owner, balance);

                case "G":
                    return new GiftCardAccount(Owner, balance);

                case "D":
                    return new debitAccount(Owner, balance);

                default:
                    throw new ArgumentException("invalid product type");


            }
            
        }

    }

    public class CreditAccount : BankAccount, ICredit_Account
    {

        public CreditAccount(string owner, double balance): base(owner,balance) 
        {
            this.Owner=owner;
            this.balance=balance;
            this.status=false;
            this.Lower_Limit = -2000;
            
        }



        public void add_intrest()
        {
            balance += balance * 0.02;

        }


        


    }


    public class GiftCardAccount : BankAccount, IGift
    {
        public GiftCardAccount(string owner, double balance) : base(owner,balance)
        {
            this.Owner = owner;
            this.balance=balance;
            this.status=false;
            this.Lower_Limit = 0;
        }

        public void add_discount(Transaction transaction)
        {
            transaction.amount -= transaction.amount * 0.25;
        }

    }

    public class debitAccount : BankAccount 
    {

        public DateOnly Expdate {  get; set; }

        public debitAccount(string owner, double balance) : base(owner, balance)
        {
            this.Owner = owner;
            this.balance=balance;
            this.status=false;
            this.comission = 0.004;
        }



    }

    public interface DebitIBuilder
    {
        DebitIBuilder setName(string name);
        DebitIBuilder setExpDate(DateOnly expDate);
        DebitIBuilder setBalance(double balance);
        debitAccount Build();
    }

    public class DebitBuilder : DebitIBuilder
    {
        private debitAccount debit = new debitAccount("ahmed", 200);


        public DebitIBuilder setName(string name)
        {
            debit.Owner = name; return this;
        }

        public DebitIBuilder setExpDate(DateOnly expDate)
        {
            debit.Expdate = expDate; return this;
        }

        public DebitIBuilder setBalance(Double balance)
        {
            debit.balance = balance; return this;
        }

        public debitAccount Build() 
        {
            return debit;
        }


    }
    
}
