using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Products
{
    public class Screw : Goods
    {
        public Screw()
        {

        }

        public Screw(string name, decimal price, int volume, DateTime dateOfRecieving, TimeSpan expirationTime, string screwType) : base(name, price, volume, dateOfRecieving, expirationTime)
        {
            this.ScrewType = screwType;
        }

        public string ScrewType { get; internal set; }
    }
}

