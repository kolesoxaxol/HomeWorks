using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humans;
using ValidationDll;

namespace VasylTravinHomeWork9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the university programm!");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n 1. Get information about all students or teachers.");
                Console.WriteLine(" 2. Get information about a specific group.");
                Console.WriteLine(" 3. Distribute new students into specific groups.");
                Console.WriteLine(" 4. Add new student to the list.");
                Console.WriteLine(" 5. Clear your screen");
                Console.WriteLine("\n 0. Exit.");
                Console.ResetColor();


                int menuSelect = Input.Validation(5, "Select a number from the menu.");
                int optionSelect;
                switch (menuSelect)
                {
                    case 1:
                        {
                            optionSelect = Input.Validation(2, "\n Please, select 1 if you want to see information about all students; " +
                                "select 2 for teachers information; select 0 if you want to return to the previous menu;");
                            switch(optionSelect)
                            {
                                case 1:
                                    {
                                        Humans.HumansLibrary.StudentList.ShowStudents();
                                        break;
                                    }
                                case 2:
                                    {
                                        Humans.HumansLibrary.TeachersList.ShowTeachers();
                                        break;
                                    }
                                case 0:
                                    {
                                        break;
                                    }
                            }
                            break;
                        }
                    case 2:
                        {
                            optionSelect = Input.Validation(3, "\n Please, select number of a group (from 1 to 3) you want to get info about. Select 0 if you want to return.");
                            if(optionSelect!=0)
                            {
                                Humans.Groups.GroupList.ShowGroups(optionSelect);
                            }
                            break;
                        }
                    case 3:
                        {
                            Humans.Groups.GroupList.Distribute();
                            break;
                        }
                    case 4:
                        {
                            Humans.HumansLibrary.StudentList.AddStudent();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            break;
                        }
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }

           
        }
    }
}
