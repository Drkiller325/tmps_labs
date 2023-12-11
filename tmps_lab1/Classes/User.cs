using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps_lab1.Classes
{
    interface Iuser
    {
        void request();
    }
    public class User : Iuser
    {
        public double Initial_Balance { get; set; }
        public string Name { get; set; }

        private static User instance;

        public User(string Name, double Initial_Balance)
        {
            this.Initial_Balance = Initial_Balance;
            this.Name = Name;  
        }

        public void request()
        {
            Console.WriteLine("User Ready");
        }

        public static User GetInstance(string Name, double Initial_Balance)
        {
            if (instance == null)
            {
                instance = new User(Name,Initial_Balance);
            }
            return instance;
        }
     
        
    }


    class User_Proxy : Iuser
    {
        private User user;
        public void request()
        {
            if(user == null)
            {
                Console.WriteLine("Creating User...");
                user = new User("John Dough",0);
            }
            user.request();
        }

    }
    
}
