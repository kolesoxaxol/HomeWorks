using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humans.HumansClass;
using Humans.HumansLibrary;

namespace Humans.Groups
{
    public class Group
    {
        //Group class that combines both Teacher and Student. Helps with organizing work with a specific student in a specific groups without any needs to call All Students Library.
        public Group(Teacher teacher, Student[] students)
        {
            this.Lector = teacher;
            this.Listeners = students;
        }

        public Teacher Lector { get; internal set; }
        public Student[] Listeners { get; internal set; }

    }
}
