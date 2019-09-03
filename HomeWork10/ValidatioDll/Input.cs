using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationDll
{
    // Just a dll I've created during the first days of study that allows to check input for integer and a specific range of numbers.
    // In the HomeWork like this it is necessary as we have to work with 40 students and mistakes are inevitable which may result in crashing. 
    public class Input
    {
        public static int Validation(int size, string text)
        {
            int menuSelect;
            string menuSelectResult;
            bool menuOptionResult;
            bool menuOption;
            do
            {

                //Message to a user about actions he has to do.
                Console.WriteLine(text);

                //Checking for integer input by user.
                menuSelectResult = Console.ReadLine();
                menuOption = int.TryParse(menuSelectResult, out menuSelect);

                if (menuOption == true)
                {
                    //Checking for input in a specific range.
                    if (menuSelect < 0 || menuSelect > size)
                    {
                        do
                        {
                            //Specified info about input.
                            Console.WriteLine($"Plese, select from 0 to {size}.");

                            menuSelectResult = Console.ReadLine();
                            menuOption = int.TryParse(menuSelectResult, out menuSelect);

                            if (0 <= menuSelect && menuSelect <= size)
                            {
                                menuOptionResult = true;
                            }
                            else
                            {
                                menuOptionResult = false;
                            }
                        }
                        while (!menuOptionResult);
                    }
                }
            }
            while (!menuOption);

            return menuSelect;
        }
    }
}
