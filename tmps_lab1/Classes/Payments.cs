﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps_lab1.Classes
{
    public class Payment : IPayment
    {
        private List<Transaction> payments = new List<Transaction>();

     
        Payment(double Balance, double Ammount)
        {
            double diff = Balance - Ammount;
            double rest = -1 * Ammount;
            Transaction transaction = new Transaction(diff, rest, "Done!");
            payments.Add(transaction);
        }
        public List<Transaction> getPayments()
        {
            return payments;

        }

        public string Status(Transaction transaction)
        {
            return transaction.Status;
        }
    }

    public class Loan : ILoan
    {
        private List<Transaction> payments = new List<Transaction>();

        public int amount;
        public double rate_per_month;
        public double intrest;

        public Loan(int amount, double rate_per_month, double intrest)
        {
            this.amount = amount;
            this.intrest = intrest;
            this.rate_per_month = rate_per_month;
        }


        public List<Transaction> getPayments()
        {
            return payments;
        }

        public string Status(Transaction transaction)
        {
            return transaction.Status;
        }

        public object LoanSettlement(int amount, double rate_per_month, double intrest)
        {
            Loan loan = new Loan(amount,rate_per_month,intrest);

            return loan;
        }

        public void initializeRepayment(BankAccount bankacconunt)
        {
            bankacconunt.balance = bankacconunt.balance - rate_per_month;
            Transaction transaction = new Transaction(bankacconunt.balance, rate_per_month, "Loan Payment Done!");
            payments.Add(transaction);

        }
    }
}
