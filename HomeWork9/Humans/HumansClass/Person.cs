using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans.HumansClass
{
    //Creating a class Person which shares similar proterties between Student and Teacher.
    public abstract class Person
    {
        internal int _age;
        internal string _testAge;

        internal string _name;
        internal string _surname;


        internal Person(string name, string surname, int age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }
        public string Name
        {
            get
            {
                return _name;
            }

            internal set
            {
                //I use this strange way of string assignation just because I accidentaly put a space " " for one specific name of a teacher at the end
                //i.e. "Name " instead of "Name", and I was getting the same message "Please, use letters only!" (watch below) again and again. 
                //Finally I figured out why this is happening and decided to make it this way, so it won't irritate me again in case of accidental spaces in pre-defined library.
                
                //Additional note: TBH, this is the first bug that triggered me really hard. Great experience anyway.
                string tempName = string.Join("",value.Split(' '));


                bool inputValid = tempName.All(Char.IsLetter);
                while (!inputValid || tempName == "")
                {
                    if (!inputValid)
                    {
                        Console.WriteLine("Please, use letters only!");
                        tempName = Console.ReadLine();
                        inputValid = tempName.All(Char.IsLetter);
                    }
                    else
                    {
                        Console.WriteLine("You didn't type a name! Try again.");
                        tempName = Console.ReadLine();
                        inputValid = tempName.All(Char.IsLetter);
                    }

                }
                _name = tempName;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }

            internal set
            {
                string tempSurname = string.Join("", value.Split(' '));
                bool surnameValid = tempSurname.All(Char.IsLetter);
                while (!surnameValid || tempSurname == "")
                {
                    if (!surnameValid)
                    {
                        Console.WriteLine("Please, use letters only!");
                        tempSurname = Console.ReadLine();
                        surnameValid = tempSurname.All(Char.IsLetter);
                    }
                    else
                    {
                        Console.WriteLine("You didn't type a surname! Try again.");
                        tempSurname = Console.ReadLine();
                        surnameValid = tempSurname.All(Char.IsLetter);
                    }

                }

                _surname = tempSurname;
            }
        }

        //I've tried to play with properties and incapsulation. There I want to make sure user provides correct value for Age, i.e int value.
        //For this reason I've created internal class TestAge that will check for correct user input. I can activate "set"er of TestAge 
        //via Console.ReadLine() and perform all validations inside internal property TestAge. After everuthing is correct, I can transfer value of
        //TestAge to Age later in the programm (see StudentList.AddStudent() ).

        public int Age
        {
            get
            {
                return _age;
            }
            internal set
            {

                _age = value;
            }
        }


        internal string TestAge
        {
            get
            {
                return _testAge;
            }
            set
            {
                int result;
                string input = value.ToString();
                while (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Enter integer value!");
                    input = Console.ReadLine();
                }
                _testAge = result.ToString();
            }
        }
    }
}
