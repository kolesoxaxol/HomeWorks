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

        public override void LogProperties()
        {
            Console.Write("\nModel: {0}\nPrice: {1}\nVolume: {2}\nDateOfProduction: {3}\nExpirationTime: {4} DD.HH:MM:SS\nGrainSize: {5}\n",
                        this.Name, this.Price, this.Volume, this.DateOfProduction, this.ExpirationTime, this.GrainSize);
        }
    }
}
