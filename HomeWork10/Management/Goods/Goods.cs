using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Goods
{
    public abstract class Goods
    {
        public Goods()
        {

        }
        public Goods(string name, decimal price, int volume, DateTime dateOfRecieving, TimeSpan expirationTime)
        {
            this.Name = name;
            this.Price = price;
            this.Volume = volume;
            this.DateOfRecieving = dateOfRecieving;
            this.ExpirationTime = expirationTime;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public DateTime DateOfRecieving { get; set; }
        public TimeSpan ExpirationTime { get; set; }

        public DateTime ExpirationDate()
        {
            DateTime expirationDate = this.DateOfRecieving + this.ExpirationTime;

            DateTime today = DateTime.Now;

            bool expired = expirationDate > today;

            if(expired)
            {
                Console.WriteLine($"This product is expired already! Expiration date: {expirationDate.Day}.{expirationDate.Month}.{expirationDate.Year}.");
            }
            else
            {
                Console.WriteLine($"This product is up to dat! Expiration date: {expirationDate.Day}.{expirationDate.Month}.{expirationDate.Year}.");
            }
            return expirationDate;
        }
    }
}
