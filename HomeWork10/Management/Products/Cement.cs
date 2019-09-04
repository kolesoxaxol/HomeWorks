using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Products
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

        //overrride of original command to represent unique properties
        public override void LogProperties()
        {
            Console.Write("\nModel: {0}\nPrice: {1}\nVolume: {2}\nDateOfProduction: {3}\nExpirationTime: {4} DD.HH:MM:SS\nBulkDensity: {5}\n",
                        this.Name, this.Price, this.Volume, this.DateOfProduction, this.ExpirationTime, this.BulkDensity);
        }
    }
}
