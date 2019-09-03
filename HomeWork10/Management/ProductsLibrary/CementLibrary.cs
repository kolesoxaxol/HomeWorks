using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Products;

namespace Management.ProductsLibrary
{
    public class CementLibrary
    {
        List<Cement> _cementLibrary = new List<Cement>();

        TimeSpan expirationTime = new TimeSpan(50, 0, 0, 0);
        internal CementLibrary()
        {
            _cementLibrary.Add(new Cement("CementA", 100, 35, DateTime.Now, expirationTime, 1.5m));
            _cementLibrary.Add(new Cement("CementB", 110, 33, DateTime.Now, expirationTime, 2m));
            _cementLibrary.Add(new Cement("CementC", 120, 31, DateTime.Now, expirationTime, 2.3m));
        }

        public Cement[] GetSand()
        {
            return _cementLibrary.ToArray();
        }

        public void ShowCement()
        {
            for(int i = 0; i< _cementLibrary.Count;i++)
            {
                Console.WriteLine($"N: {i}, Model: {_cementLibrary[i].Name}, Price: {_cementLibrary[i].Price}, Volume per unit: {_cementLibrary[i].Volume}, Bulk density: {_cementLibrary[i].BulkDensity}.");
            }
        }

    }
}
