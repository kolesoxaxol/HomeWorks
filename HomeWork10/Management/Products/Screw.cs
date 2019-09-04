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

        //overrride of original command to represent unique properties
        public override void LogProperties()
        {
            Console.Write("\nName: {0}\nPrice: {1}\nVolume: {2}\nDateOfProduction: {3}\nExpirationTime: {4} DD.HH:MM:SS\nGrainSize: {5}\n",
                        this.Name, this.Price, this.Volume, this.DateOfProduction, this.ExpirationTime, this.ScrewType);
        }
    }
}

