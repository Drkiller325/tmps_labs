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

    public interface Membership
    {
        void Create_membership();
    }

    class Member : Membership
    {
        private string clubname;

        public Member(string clubname)
        {
            this.clubname = clubname;
        }

        public void Create_membership()
        {
            Console.WriteLine($"you're a member of the {clubname} club");
        }
    }

    public class FlyWeightFactory
    {
        private Dictionary<string, Membership> flyweights = new Dictionary<string, Membership>();

        public Membership GetFlyweight(string key)
        {
            if (!flyweights.TryGetValue(key, out Membership member))
            {
                member = new Member(key);
                flyweights[key] = member;
            }
            return member;
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

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class ConcreteSubject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private int state;

        public int State
        {
            get { return state; }
            set
            {
                state = value;
                Notify();
            }
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }

    public interface IObserver
    {
        void Update();
    }

    public class ConcreteObserver : IObserver
    {
        private string name;
        private ConcreteSubject subject;

        public ConcreteObserver(string name, ConcreteSubject subject)
        {
            this.name = name;
            this.subject = subject;
            subject.Attach(this);
        }

        public void Update()
        {
            Console.WriteLine($"Observer {name} received update. Subject state: {subject.State}");
        }
    }

    public interface IMediator
    {
        void SendMessage(string message, Colleague colleague);
    }

  
    public abstract class Colleague
    {
        protected IMediator mediator;

        public Colleague(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void ReceiveMessage(string message);
    }

    
    public class ConcreteMediator : IMediator
    {
        private ConcreteColleague1 colleague1;
        private ConcreteColleague2 colleague2;

        public ConcreteColleague1 Colleague1
        {
            set { colleague1 = value; }
        }

        public ConcreteColleague2 Colleague2
        {
            set { colleague2 = value; }
        }

        public void SendMessage(string message, Colleague colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.ReceiveMessage(message);
            }
            else if (colleague == colleague2)
            {
                colleague1.ReceiveMessage(message);
            }
        }
    }

    public class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(IMediator mediator) : base(mediator) { }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine("Colleague1 received message: " + message);
        }

        public void Send(string message)
        {
            mediator.SendMessage(message, this);
        }
    }

    public class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(IMediator mediator) : base(mediator) { }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine("Colleague2 received message: " + message);
        }

        public void Send(string message)
        {
            mediator.SendMessage(message, this);
        }
    }

}
