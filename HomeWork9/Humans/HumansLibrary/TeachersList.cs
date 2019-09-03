using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humans.HumansClass;

namespace Humans.HumansLibrary
{
    public static class TeachersList
    {
        static List<Teacher> _teacherList;

        static TeachersList()
        {
            _teacherList = new List<Teacher>();

            _teacherList.Add(new Teacher("Nameless", "Apprentice", 100, 1));
            _teacherList.Add(new Teacher("TheDark", "One", 200, 2));
            _teacherList.Add(new Teacher("Vladimir", "Drakula", 587, 3));
        }

        public static Teacher[] GetTeachers()
        {
            return _teacherList.ToArray();
        }

        public static void ShowTeachers()
        {
            Console.WriteLine("\n========================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Teachers:\n");
            Console.ResetColor();

            for (int i = 0; i < TeachersList.GetTeachers().Length; i++)
            {
                Console.WriteLine(String.Format("N: {0,0}, Name: {1,10}, Surname: {2,10}, Age: {3,3}, Group: {4,3}", i + 1, TeachersList.GetTeachers()[i].Name, TeachersList.GetTeachers()[i].Surname, TeachersList.GetTeachers()[i].Age, i+1));

            }
            Console.WriteLine("========================================");
        }
    }
}
