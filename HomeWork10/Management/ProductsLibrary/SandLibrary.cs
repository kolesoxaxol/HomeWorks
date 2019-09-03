using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Products;

namespace Management.ProductsLibrary
{
    public class SandLibrary
    {
         List<Sand> _sandLibrary = new List<Sand>();

        TimeSpan expirationTime = new TimeSpan(10, 0, 0, 0);
        internal SandLibrary()
        {
            _sandLibrary.Add(new Sand("SandA", 60, 35, DateTime.Now, expirationTime, 10));
            _sandLibrary.Add(new Sand("SandB", 70, 35, DateTime.Now, expirationTime, 8));
            _sandLibrary.Add(new Sand("SandC", 800, 35, DateTime.Now, expirationTime, 6));
        }

        public Sand[] GetSand()
        {
            return _sandLibrary.ToArray();
        }

        public void ShowSand()
        {
            for (int i = 0; i < _sandLibrary.Count; i++)
            {
                Console.WriteLine($"N: {i}, Model: {_sandLibrary[i].Name}, Price: {_sandLibrary[i].Price}, Volume per unit: {_sandLibrary[i].Volume}, Grain size: {_sandLibrary[i].GrainSize}.");
            }
        }
    }
}
