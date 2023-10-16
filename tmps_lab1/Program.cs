using tmps_lab1.Classes;

IBankAccount account = new CreditAccount(); 
Person ahmed =  new Person("Ahmed",500);

object acc = account.Create_Account(ahmed.Name, ahmed.Initial_Balance);

Console.WriteLine(acc);



