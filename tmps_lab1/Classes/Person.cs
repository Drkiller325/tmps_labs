using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps_lab1.Classes
{
    public class Person
    {
        public double Initial_Balance { get; set; }
        public string Name { get; set; }

        public Person(string Name, double Initial_Balance)
        {
            this.Initial_Balance = Initial_Balance;
            this.Name = Name;  
        }
        

        

        
        
    }

    
}
