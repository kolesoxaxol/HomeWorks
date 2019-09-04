using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Products;

namespace Management.ProductsLibrary
{
    public static class CementLibrary
    {

        private static List<Cement> _cementLibrary;

        //individual expiration time. Can be set for each product to be different
        private static TimeSpan _expirationTime = new TimeSpan(50, 0, 0, 0);
        static CementLibrary()
        {
            _cementLibrary = new List<Cement>();
            _cementLibrary.Add(new Cement("CementA", 100, 35, DateTime.Now, _expirationTime, 1.5m));
            _cementLibrary.Add(new Cement("CementB", 110, 33, DateTime.Now, _expirationTime, 2m));
            _cementLibrary.Add(new Cement("CementC", 120, 31, DateTime.Now, _expirationTime, 2.3m));
        }

        public static Cement[] GetGoods()
        {
            return _cementLibrary.ToArray();
        }

        public static void ShowGoods()
        {
            for(int i = 0; i< _cementLibrary.Count;i++)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\nN: {i}\n");
                Console.ResetColor();

                _cementLibrary[i].LogProperties();
                Console.WriteLine("----------------------------");
            }
        }

    }
}
