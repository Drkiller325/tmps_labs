using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace tmps_lab1.Classes
{

    public abstract class Account
    {
        public abstract void generate_Acc_num();
    }


    public interface ICloanable<T>
    {
        T Clone();
    }

    public interface IBankAccount
    {
        void Activate_Account();
        BankAccount Create_Account(string Owner, double balance,string type);
        object CheckStatus();
    }

    public interface ICredit_Account: IBankAccount 
    {
        void add_intrest();
    }


    public interface IGift : IBankAccount
    {
        void add_discount(Transaction transaction);
    }

    





    public interface IPayment
    {

        List<Transaction> getPayments();

        string Status(Transaction transaction);
    }

    public interface ILoan : IPayment
    {
        Loan LoanSettlement(int amount, double rate_per_month, double intrest);

        void initializeRepayment(BankAccount bankacconunt);
    }

    public interface IBank : IPayment
    {
        void initializePayments();
    }
}
