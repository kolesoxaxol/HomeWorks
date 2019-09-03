using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humans.HumansClass;
using Humans.Groups;

namespace Humans.HumansLibrary
{
    public static class StudentList
    {

        static List<Student> _studentList;
        //Some students are temporaly not in the list, because it's easier to test programm with lesser amount of people.
        static StudentList()
        {
            // 0 int group number states for "Not in group" as groups count from 1 to 3.
            _studentList = new List<Student>();

            _studentList.Add(new Student("VasyaOne", "PetkinOne", 24, 0));
            _studentList.Add(new Student("VasyaTwo", "PetkinTwo", 23, 0));
            _studentList.Add(new Student("VasyaT", "PetkinT", 22, 0));
            _studentList.Add(new Student("VasyaF", "PetkinF", 21, 0));
            _studentList.Add(new Student("VasyaFv", "PetkinFv", 20, 0));

            _studentList.Add(new Student("DimaOne", "LebedevOne", 24, 0));
            _studentList.Add(new Student("DimaTwo", "LebedevTwo", 23, 0));
            _studentList.Add(new Student("DimaT", "LebedevT", 22, 0));
            _studentList.Add(new Student("DimaF", "LebedevF", 21, 0));
            _studentList.Add(new Student("DimaFv", "LebedevFv", 20, 0));

            ////_studentList.Add(new Student("VanyaOne", "SmolinOne", 24, 0));
            ////_studentList.Add(new Student("VanyaTwo", "SmolinTwo", 23, 0));
            ////_studentList.Add(new Student("VanyaT", "SmolinT", 22, 0));
            ////_studentList.Add(new Student("VanyaF", "SmolinF", 21, 0));
            ////_studentList.Add(new Student("VanyaFv", "SmolinFv", 20, 0));

            ////_studentList.Add(new Student("SlavikOne", "PetrushinOne", 24, 0));
            ////_studentList.Add(new Student("SlavikTwo", "PetrushinTwo", 23, 0));
            ////_studentList.Add(new Student("SlavikT", "PetrushinT", 22, 0));
            //_studentList.Add(new Student("SlavikF", "PetrushinF", 21, 0));
            //_studentList.Add(new Student("SlavikFv", "PetrushinFv", 20, 0));

            //_studentList.Add(new Student("VasyaOne", "SmolinOne", 24, 0));
            //_studentList.Add(new Student("VasyaTwo", "SmolinTwo", 23, 0));
            //_studentList.Add(new Student("VasyaT", "SmolinT", 22, 0));
            //_studentList.Add(new Student("VasyaF", "SmolinF", 21, 0));
            //_studentList.Add(new Student("VasyaFv", "SmolinFv", 20, 0));

            //_studentList.Add(new Student("DimaOne", "PetrushinOne", 24, 0));
            //_studentList.Add(new Student("DimaTwo", "PetrushinTwo", 23, 0));
            //_studentList.Add(new Student("DimaT", "PetrushinT", 22, 0));
            //_studentList.Add(new Student("DimaF", "PetrushinF", 21, 0));
            //_studentList.Add(new Student("DimaFv", "PetrushinFv", 20, 0));

            //_studentList.Add(new Student("VanyaOne", "PetkinOne", 24, 0));
            //_studentList.Add(new Student("VanyaTwo", "PetkinTwo", 23, 0));
            //_studentList.Add(new Student("VanyaT", "PetkinT", 22, 0));
            //_studentList.Add(new Student("VanyaF", "PetkinF", 21, 0));
            //_studentList.Add(new Student("VanyaFv", "PetkinFv", 20, 0));

            //_studentList.Add(new Student("SlavikOne", "LebedevOne", 24, 0));
            //_studentList.Add(new Student("SlavikTwo", "LebedevTwo", 23, 0));
            //_studentList.Add(new Student("SlavikT", "LebedevT", 22, 0));
            //_studentList.Add(new Student("SlavikF", "LebedevF", 21, 0));
            //_studentList.Add(new Student("SlavikFv", "LebedevFv", 20, 0));
        }

        public static Student[] GetStudents()
        {
            return _studentList.ToArray();
        }

        public static void AddStudent()
        {
            var newStudent = new Student("F", "F", 0, 0);

            Console.WriteLine("Give a name of a student:");
            newStudent.Name = Console.ReadLine();

            Console.WriteLine("Give a surname of a student:");
            newStudent.Surname = Console.ReadLine();

            Console.WriteLine("Give an age of a student:");

            //Person class has two different properties: string TestAge and int Age. TestAge is internal class. I assign to TestAge what user types
            //into the programm. "set" method checks for pure integer values and if they are not integer - it returns an error and asks to try again.
            //after correct value was defined for TestAge I transfer it to Age so I can use it later on.

            newStudent.TestAge = Console.ReadLine();
            newStudent.Age = int.Parse(newStudent.TestAge);

            //When new Student is created he doesn't have a group yet and has to be assigned.
            _studentList.Add(newStudent);
        }

        public static void ShowStudents()
        {
            Console.WriteLine("\n========================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("All Students:\n");
            Console.ResetColor();

            for (int i = 0; i < StudentList.GetStudents().Length; i++)
            {

                Console.WriteLine(String.Format("N: {0,0}, Name: {1,10}, Surname: {2,10}, Age: {3,3}, Group: {4,3}",i+1, StudentList.GetStudents()[i].Name, StudentList.GetStudents()[i].Surname, StudentList.GetStudents()[i].Age, (StudentList.GetStudents()[i].GroupNumb==0)? "Not assigned yet" : $"{StudentList.GetStudents()[i].GroupNumb}"));
            }
            Console.WriteLine("========================================");
        }
    }
}
