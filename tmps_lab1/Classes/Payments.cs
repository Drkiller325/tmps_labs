namespace tmps_lab1.Classes
{
    public class Payment : IPayment
    {
        private List<Transaction> payments = new List<Transaction>();


        Payment(double Balance, double Ammount)
        {
            double diff = Balance - Ammount;
            double rest = -1 * Ammount;
            Transaction transaction = new Transaction(diff, rest, "Done!", payments.Count);
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
        private List<Loan> loans = new List<Loan>();

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

        public Loan LoanSettlement(int amount, double rate_per_month, double intrest)
        {
            Loan loan = new Loan(amount, rate_per_month, intrest);
            loans.Add(loan);
            return loan;
        }

        public void initializeRepayment(BankAccount bankacconunt)
        {
            bankacconunt.balance = bankacconunt.balance - rate_per_month;
            Transaction transaction = new Transaction(bankacconunt.balance, rate_per_month, "Loan Payment Done!", payments.Count);
            payments.Add(transaction);

        }

        public void repeat_payment(int ID)
        {
            for (int i = 0; i < payments.Count; i++)
            {
                if (payments[i].ID == ID)
                {
                    Transaction tran = (Transaction)payments[i].Clone();
                    payments.Add((Transaction)tran);
                    break;
                }
            }
        }

    }
    public interface IHandler
    {
        IHandler NextHandler { get; set; }
        void HandlePayment(double amout);
    }

    public class Handler1 : IHandler
    {
        public IHandler NextHandler { get; set; }

        public void HandlePayment(double amout)
        {
            if (amout <= 100)
            {
                Console.WriteLine("Payment proccessed");
            }
            else if (NextHandler != null)
            {
                Console.WriteLine("Amount exceeded the limit, passing to PIN management");
                NextHandler.HandlePayment(amout);
            }
            else
            {
                Console.WriteLine("end of chain, payment not processed");
            }
        }
        

    }
    public class Handler2 : IHandler
    {
        public IHandler NextHandler { get; set; }

        public void HandlePayment(double amout)
        {
            if (amout > 100 && amout <= 2000)
            {
                Console.WriteLine("Requesting PIN....");
                Console.WriteLine("Payment processed");
            }
            else if (NextHandler != null)
            {
                Console.WriteLine("Payment amount too big, passing to call verification");
                NextHandler.HandlePayment((double)amout);
            }
            else
            {
                Console.WriteLine("end of chain, payment not processed");
            }

        }
    }

}
