using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Products;

namespace Management.ProductsLibrary
{
    public class ScrewLibrary
    {
        List<Screw> _screwLibrary = new List<Screw>();

        TimeSpan expirationTime = new TimeSpan(1000, 0, 0, 0);
        internal ScrewLibrary()
        {
            _screwLibrary.Add(new Screw("ScrewA", 10, 5, DateTime.Now, expirationTime, "Cross"));
            _screwLibrary.Add(new Screw("ScrewB", 25, 10, DateTime.Now, expirationTime, "Self-tapping screw"));
        }

        public Screw[] GetScrew()
        {
            return _screwLibrary.ToArray();
        }

        public void ShowScrew()
        {
            for (int i = 0; i < _screwLibrary.Count; i++)
            {
                Console.WriteLine($"N: {i}, Model: {_screwLibrary[i].Name}, Price: {_screwLibrary[i].Price}, Volume per unit: {_screwLibrary[i].Volume}, Screw type: {_screwLibrary[i].ScrewType}.");
            }
        }
    }
}
