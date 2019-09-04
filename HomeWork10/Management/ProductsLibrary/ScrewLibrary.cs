using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Products;

namespace Management.ProductsLibrary
{
    public static class ScrewLibrary
    {
        private static List<Screw> _screwLibrary;

        //individual expiration time. Can be set for each product to be different
        private static TimeSpan _expirationTime = new TimeSpan(1000, 0, 0, 0);
        static ScrewLibrary()
        {
            _screwLibrary = new List<Screw>();
            _screwLibrary.Add(new Screw("ScrewA", 10, 5, DateTime.Now, _expirationTime, "Cross"));
            _screwLibrary.Add(new Screw("ScrewB", 25, 10, DateTime.Now, _expirationTime, "Self-tapping screw"));
        }

        public static Screw[] GetScrew()
        {
            return _screwLibrary.ToArray();
        }

        public static void ShowScrew()
        {
            for (int i = 0; i < _screwLibrary.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\nN: {i}\n");
                Console.ResetColor();

                _screwLibrary[i].LogProperties();
            }
        }
    }
}
