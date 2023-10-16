using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps_lab1.Classes
{
    public interface IBankAccount
    {
        void Activate_Account();
        object Create_Account(string Owner, double balance);
    }

    public interface ICredit_Account: IBankAccount 
    {

    }

    public interface IPayment
    {

        List<Transaction> getPayments();

        string Status(Transaction transaction);
    }

    public interface ILoan : IPayment
    {
        object LoanSettlement(int amount, double rate_per_month, double intrest);

        void initializeRepayment(BankAccount bankacconunt);
    }

    public interface IBank : IPayment
    {
        void initializePayments();
    }
}
