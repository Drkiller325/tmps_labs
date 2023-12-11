using tmps_lab1.Classes;

User person = User.GetInstance("ahmed", 2000);

IBankAccount bankAccount = new BankAccount(person.Name,person.Initial_Balance);
bankAccount.Activate_Account();

BankAccount bankAccount1 = bankAccount.Create_Account(person.Name, person.Initial_Balance, "C");
bankAccount1.Activate_Account();

Console.WriteLine(bankAccount1.Lower_Limit);

DebitIBuilder builder = new DebitBuilder();
DateOnly date = new DateOnly(2027, 10, 24);

debitAccount debit = builder
    .setName(person.Name)
    .setBalance(person.Initial_Balance)
    .setExpDate(date)
    .Build();

Console.WriteLine(debit.Expdate);

FlyWeightFactory flyWeight = new FlyWeightFactory();

Membership membership1 = new Member("baseball");
Membership membership2 = new Member("mall");
Membership membership3 = new Member("baseball");

membership1.Create_membership();
membership2.Create_membership();
membership3.Create_membership();

Transaction t = new Transaction(bankAccount1.balance, 100, "payment", 1);

Pay_in_store pay = new Pay_in_store(t);
pay.Pay(t);

Iuser use = new User_Proxy();
use.request();

IHandler handler1 = new Handler1();
IHandler handler2 = new Handler2();

handler1.NextHandler = handler2;

handler1.HandlePayment(100);
handler1.HandlePayment(1000);
handler1.HandlePayment(5000);


ConcreteSubject subject = new ConcreteSubject();
ConcreteObserver observer1 = new ConcreteObserver("Observer1", subject);
ConcreteObserver observer2 = new ConcreteObserver("Observer2", subject);

subject.State = 10;