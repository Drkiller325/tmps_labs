using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps_lab1.Classes
{
    public class User
    {
        public double Initial_Balance { get; set; }
        public string Name { get; set; }

        private static User instance;

        private User(string Name, double Initial_Balance)
        {
            this.Initial_Balance = Initial_Balance;
            this.Name = Name;  
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

    
}
