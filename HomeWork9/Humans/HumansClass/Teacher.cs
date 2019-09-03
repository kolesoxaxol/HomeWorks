using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans.HumansClass
{
    public class Teacher : Person
    {
        internal Teacher(string name, string surname, int age, int academyLevel) : base(name, surname, age)
        {
            this.AcademyLevel = academyLevel;
        }

        //Even though Teacher and Student classes have the fourth property of the same type I make them separated from each other.
        //First - it makes easier to opperate with them. Second, it's easier to change group number of a Student rather than Academy Level of a Teacher in real life.
        //I set AcademyLevel to private and, possibly, there can be  a method that allows to ascend or descend Academy Level if all requirements are met and specific trusted user gave a permission for this.

        public int AcademyLevel { get; }

    }
}
