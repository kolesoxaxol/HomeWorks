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
        private static List<Sand> _sandLibrary = new List<Sand>();

        private static TimeSpan _expirationTime = new TimeSpan(10, 0, 0, 0);
        static SandLibrary()
        {
            _sandLibrary.Add(new Sand("SandA", 60, 35, DateTime.Now, _expirationTime, 10));
            _sandLibrary.Add(new Sand("SandB", 70, 35, DateTime.Now, _expirationTime, 8));
            _sandLibrary.Add(new Sand("SandC", 800, 35, DateTime.Now, _expirationTime, 6));
        }

        public static Sand[] GetSand()
        {
            return _sandLibrary.ToArray();
        }

        public static void ShowSand()
        {
            for (int i = 0; i < _sandLibrary.Count; i++)
            {
                Console.WriteLine($"N: {i}, Model: {_sandLibrary[i].Name}, Price: {_sandLibrary[i].Price}, Volume per unit: {_sandLibrary[i].Volume}, Grain size: {_sandLibrary[i].GrainSize}.");
            }
        }

    }
}
