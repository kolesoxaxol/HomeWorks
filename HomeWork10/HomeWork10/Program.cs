using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Products;
using Management.ProductsLibrary;
using Management.Stock;

namespace HomeWork10
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the shop management!");
            Console.WriteLine("-------------------------------");
            
            while(true)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("1. Show items at your stock.");
                Console.WriteLine("2. Show items at the shop.");
                Console.WriteLine("3. Buy items at the shop.");
                Console.WriteLine("4. Sell items from the stock.");
                Console.WriteLine("5. Check for expired goods at the stock.");
                Console.WriteLine("6. Clean console.");
                Console.WriteLine("===========================================");
                Console.WriteLine("0. Exit.");

                int menuSize = 6;

                string request = "Please, select one item from the menu";

                int input = ValidationDll.Input.Validation(menuSize, request);

                switch(input)
                {
                    case 1:
                        {
                            Stock.ShowStock();
                            break;
                        }
                    case 2:
                        {
                            Market.ShowGoodsList();
                            Market.ShowSpecificGoods();
                            break;
                        }
                    case 3:
                        {
                            Stock.BuyGoods();
                            break;
                        }
                    case 4:
                        {
                            Stock.SellGoods();
                            break;
                        }
                    case 5:
                        {
                            Stock.ExpiredGoods();

                            request = "Do you want to clear stock from Expired goods?";
                            int yesAnswer = 1;

                            input = ValidationDll.Input.Validation(yesAnswer, request);

                            if (input == 1)
                            {
                                Stock.RemoveExpiredGoods();
                            }

                            break;
                        }
                    case 6:
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
