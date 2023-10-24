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
