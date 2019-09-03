using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Humans.HumansClass
{

    public class Student : Person
    {
        internal Student(string name, string surname, int age, int groupNumb) : base(name, surname, age)
        {
            this.GroupNumb = groupNumb;
        }
        public int GroupNumb {get; set;}

        
    }
}
