using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humans.HumansClass;
using Humans.HumansLibrary;
using ValidationDll;

namespace Humans.Groups
{


    public static class GroupList
    {
        //PREPARATIONS

        //Because I created custom class and didn't implement IEnumerate, I have to find an index of a specific student in StudentList by myself.
        static int FindIndexStudent(Student student)
        {
            int index = -1;
            for (int i = 0; i < StudentList.GetStudents().Length; i++)
            {
                if (student == StudentList.GetStudents()[i])
                {
                    index = i;
                }
            }
            return index;
        }

        //Groups overload function. It has 6 arguments that are paired as follows studentCount1 <=> groupSize1, etc. If they are both equal -> function gives an error message.
        //It returns a number of a group student has to be assigned to.
        static int Overload(int studentsCount1, int studentsCount2, int studentsCount3, int groupSize1, int groupSize2, int groupSize3)
        {
            int groupNumb;
            while (true)
            {
                groupNumb = Input.Validation(3, "Please, select a group number (from 1 to 3) you want to add this Student to. Select \"0\" if you want to select another student.");
                if (groupNumb == 1 && studentsCount1 == groupSize1)
                {
                    Console.WriteLine("This group is full. Select another one!\n");
                }
                else if (groupNumb == 2 && studentsCount2 == groupSize2)
                {
                    Console.WriteLine("This group is full. Select another one!\n");
                }
                else if (groupNumb == 3 && studentsCount3 == groupSize3)
                {
                    Console.WriteLine("This group is full. Select another one!\n");
                }
                else if (groupNumb == 0)
                {
                    //nothing happens there, cycle continues.
                }
                else
                {
                    break;
                }
            }

            return groupNumb;
        }

        //Just a QoL thing to help user see results of his action.
        static void DistMessage(int group, Student student)
        {
            Console.WriteLine($"\nYou assigned student Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age} to a group Number {group}\n");
        }


        //All preparations have been made. Now to the main part.

        //Declaration of variables. 

        static Group[] _groups = new Group[3];

        static Student[] _groupNum1;
        static Student[] _groupNum2;
        static Student[] _groupNum3;

        //Constructor.

        static GroupList()
        {
            _groupNum1 = new Student[5];
            _groupNum2 = new Student[15];
            _groupNum3 = new Student[20];

            _groups[0] = new Group(TeachersList.GetTeachers()[0], _groupNum1);
            _groups[1] = new Group(TeachersList.GetTeachers()[1], _groupNum2);
            _groups[2] = new Group(TeachersList.GetTeachers()[2], _groupNum3);
        }

        //DESCRIPTION ABOUT HOW DISTRIBUTION METHOD WORKS!

        //Distribution method. This method allows to distribute all new students (that have GroupNumber = 0) to a specific group.
        //First, it checks for students that can de distributed (GroupNumb = 0) and if so, puts them to an individual list.
        //Second, it checks for Students Count in the list. If count is 0 -> a massage will occure about all students have been distributed already and method STOPS.
        //Third, it asks to select a specific student from the list by his Number. If 0 is selected -> method STOPS (per request).
        //Fourth, it asks about group number this student has to be assigned to.
        //Fifth, it checks for availability of a selected group with a help of Overload function.
        //If group is full already, it will ask to select another group.
        //Sixth, with a help of DistMessage user get info about his actions; this student gets put into a dedicated group array _groupNum;
        //this student gets removed from temp list "allStudents" -> this will help to check for duplicates of the same person; 
        //GroupNumber in StudentList of this specific student gets updated so he will no longer contribute in distribution function in further runs.

        public static void Distribute()
        {

            List<Student> allStudents = new List<Student>();

            //building a list of new students with (GroupNumb = 0).
            for (int i = 0; i < StudentList.GetStudents().Length; i++)
            {
                if (StudentList.GetStudents()[i].GroupNumb == 0)
                {
                    allStudents.Add(StudentList.GetStudents()[i]);
                }
            }

            //check for amount of new students.
            bool newStudents = true;

            if (allStudents.Count == 0)
            {
                Console.WriteLine("All student already distributed between groups!");
                newStudents = false;
            }

            //Intermidiate check for number of students already in the group in case Distribute method will be run multiple times.
            int studentCount1 = 0;
            int studentCount2 = 0;
            int studentCount3 = 0;

            for (int i = 0; i < 5; i++)
            {
                if (_groupNum1[i] != null)
                {
                    studentCount1++;
                }
            }
            for (int i = 0; i < 15; i++)
            {
                if (_groupNum2[i] != null)
                {
                    studentCount2++;
                }
            }
            for (int i = 0; i < 20; i++)
            {
                if (_groupNum3[i] != null)
                {
                    studentCount3++;
                }
            }
            //intermediate check end.


            while (studentCount1 + studentCount2 + studentCount3 < StudentList.GetStudents().Length && newStudents)
            {
                //duplicated list of students that can be assigned.
                Console.WriteLine("========================================");
                for (int i = 0; i < allStudents.Count; i++)
                {

                    Console.WriteLine($"N: { i + 1, 0}, Name: { allStudents[i].Name, 10}, Surname: { allStudents[i].Surname, 10}, Age: { allStudents[i].Age, 3}");

                }
                Console.WriteLine("========================================");
                //selection of a student.
                int studentNum = -1 + Input.Validation(allStudents.Count, "Select number N of a student you want to assign to a specific group or select 0 if you want to quit.");

                if (studentNum == -1)
                {
                    break;
                }

                //selection of a group.
                int groupNum = Overload(studentCount1, studentCount2, studentCount3, 5, 15, 20);

                switch (groupNum)
                {
                    case 1:
                        {

                            //message to user
                            DistMessage(groupNum, allStudents[studentNum]);

                            //assigning student to a GroupList collection.
                            _groupNum1[studentCount1] = allStudents[studentNum];

                            //changing GroupNumb of this student in StudentList collection.
                            StudentList.GetStudents()[FindIndexStudent(allStudents[studentNum])].GroupNumb = 1;

                            //removing student from the temporary list.
                            allStudents.Remove(allStudents[studentNum]);

                            //increasing counter of students in the group.
                            studentCount1++;
                            break;

                        }
                    case 2:
                        {

                            DistMessage(groupNum, allStudents[studentNum]);

                            _groupNum2[studentCount2] = allStudents[studentNum];

                            StudentList.GetStudents()[FindIndexStudent(allStudents[studentNum])].GroupNumb = 2;

                            allStudents.Remove(allStudents[studentNum]);

                            studentCount2++;

                            break;
                        }
                    case 3:
                        {

                            DistMessage(groupNum, allStudents[studentNum]);

                            _groupNum3[studentCount3] = allStudents[studentNum];

                            StudentList.GetStudents()[FindIndexStudent(allStudents[studentNum])].GroupNumb = 3;

                            allStudents.Remove(allStudents[studentNum]);

                            studentCount3++;

                            break;
                        }
                    case 0:
                        {
                            //return to a Student selection
                            break;
                        }
                }
            }

        }


        //returning groups.
        public static Group[] GetGroups()
        {

            return _groups;
        }

        //showing info about a specific group.
        public static void ShowGroups(int groupNumb)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nDetailed information about group number {groupNumb}:\n");
            Console.ResetColor();

            Console.WriteLine("========================================");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Teacher:");
            Console.ResetColor();


            Console.WriteLine($"{ GroupList.GetGroups()[groupNumb - 1].Lector.Name, 0} {GroupList.GetGroups()[groupNumb - 1].Lector.Surname, 5}, {GroupList.GetGroups()[groupNumb - 1].Lector.Age, 3} years old, Academy level: {GroupList.GetGroups()[groupNumb - 1].Lector.AcademyLevel, 3}.\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Students:");
            Console.ResetColor();

            for (int i = 0; i < GroupList.GetGroups()[groupNumb - 1].Listeners.Length; i++)
            {
                if (GroupList.GetGroups()[groupNumb - 1].Listeners[i] != null)
                {
                    Console.WriteLine($"N: {i + 1, 0}, Name: {GroupList.GetGroups()[groupNumb - 1].Listeners[i].Name, 10}, Surname: {GroupList.GetGroups()[groupNumb - 1].Listeners[i].Surname, 10}, Age: {GroupList.GetGroups()[groupNumb - 1].Listeners[i].Age, 3}.");
                }
            }

            Console.WriteLine("========================================");
        }
    }
}
