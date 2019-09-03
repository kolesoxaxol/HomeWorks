using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Products
{
    public class Sand : Goods
    {
        public Sand()
        {

        }

        public Sand(string name, decimal price, int volume, DateTime dateOfRecieving, TimeSpan expirationTime, int grainSize) : base(name, price, volume, dateOfRecieving, expirationTime)
        {
            this.GrainSize = grainSize;
        }

        public int GrainSize { get; internal set; }
    }
}
