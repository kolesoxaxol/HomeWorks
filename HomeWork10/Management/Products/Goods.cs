using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Products
{
    public abstract class Goods
    {
        public Goods()
        {

        }
        public Goods(string name, decimal price, int volume, DateTime dateOfProduction, TimeSpan expirationTime)
        {
            this.Name = name;
            this.Price = price;
            this.Volume = volume;
            this.DateOfProduction = dateOfProduction;
            this.ExpirationTime = expirationTime;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public DateTime DateOfProduction { get; set; }
        public TimeSpan ExpirationTime { get; set; }

    }
}
