using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Goods
{
    public class SandProducts : Goods
    {
        public SandProducts()
        {

        }

        public SandProducts(string name, decimal price, int volume, DateTime dateOfRecieving, TimeSpan expirationTime) : base(name, price, volume, dateOfRecieving, expirationTime)
        {
            
        }
    }
}
