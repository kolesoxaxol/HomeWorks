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
        private static List<Screw> _screwLibrary = new List<Screw>();

        private static TimeSpan _expirationTime = new TimeSpan(1000, 0, 0, 0);
        static ScrewLibrary()
        {
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
                Console.WriteLine($"N: {i}, Model: {_screwLibrary[i].Name}, Price: {_screwLibrary[i].Price}, Volume per unit: {_screwLibrary[i].Volume}, Screw type: {_screwLibrary[i].ScrewType}.");
            }
        }
    }
}
