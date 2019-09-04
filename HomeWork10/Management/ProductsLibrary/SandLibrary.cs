using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Products;

namespace Management.ProductsLibrary
{
    public static class SandLibrary
    {
        private static List<Sand> _sandLibrary;

        //individual expiration time. Can be set for each product to be different
        private static TimeSpan _expirationTime = new TimeSpan(10, 0, 0, 0);
        static SandLibrary()
        {
            _sandLibrary = new List<Sand>();
            _sandLibrary.Add(new Sand("SandA", 60, 35, DateTime.Now, _expirationTime, 10));
            _sandLibrary.Add(new Sand("SandB", 70, 35, DateTime.Now, _expirationTime, 8));
            _sandLibrary.Add(new Sand("SandC", 80, 35, DateTime.Now, _expirationTime, 6));
        }

        public static Sand[] GetGoods()
        {
            return _sandLibrary.ToArray();
        }

        public static void ShowGoods()
        {
            for (int i = 0; i < _sandLibrary.Count; i++)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\nN: {i}\n");
                Console.ResetColor();

                _sandLibrary[i].LogProperties();
                Console.WriteLine("----------------------------");
            }
        }

    }
}
