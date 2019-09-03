using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Goods
{
    public class Cement : Goods
    {
        public Cement()
        {

        }

        public Cement(string name, decimal price, int volume, DateTime dateOfRecieving, TimeSpan expirationTime, decimal bulkDensity) : base(name, price, volume, dateOfRecieving, expirationTime)
        {
            this.BulkDensity = bulkDensity;
        }

        public decimal BulkDensity { get; internal set; }
    }
}
