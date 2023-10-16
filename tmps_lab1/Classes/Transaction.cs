using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps_lab1.Classes
{
    public class Transaction
    {
        public double Balance { get; set; }
        public double amount { get; set; }

        public string Status { get; set; }
        public Transaction(double Balance,double amount, String Status) 
        {
            this.Balance = Balance;
            this.amount = amount; 
            this.Status = Status;
        }



        

    }
}
