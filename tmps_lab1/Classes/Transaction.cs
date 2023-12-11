using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps_lab1.Classes
{
    public class Transaction : ICloanable<Transaction>
    {
        public double Balance { get; set; }
        public double amount { get; set; }

        public string Status { get; set; }
        public int ID { get; set; }
        public Transaction(double Balance,double amount, String Status,int ID) 
        {
            this.Balance = Balance;
            this.amount = amount; 
            this.Status = Status;
            this.ID = ID;
        }

        public Transaction Clone()
        {
            return new Transaction(Balance,amount,Status,ID);
        }


        

    }

    public class Commision
    {
        public void apply_commision(Transaction t)
        {
            t.amount = t.amount + t.amount * 0.02;
            Console.WriteLine("commision applied");
        }
    }

    public class PayFees
    {
        public void apply_fee(Transaction t)
        {
            t.amount += 2;
            Console.WriteLine("Fees paid");
        }
    }

    public class Pay_in_store
    {
        private Transaction t;
        private Commision commision;
        private PayFees fee;

        public Pay_in_store(Transaction t)
        {
            this.t = t;
            commision = new Commision();
            fee = new PayFees();

        }

        public void Pay(Transaction t)
        {
            commision.apply_commision(t);
            fee.apply_fee(t);
            Console.WriteLine("Payment Done!");
        }
    }

}
