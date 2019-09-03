using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Products;

namespace Management.Stock
{
    public static class Stock
    {
        static List<Goods> _goods;

        static int _capacity = 1000;

        static int _currentLoad = 0;

        static Stock()
        {
            _goods = new List<Goods>();
        }

        static void AddGoods(Goods goods, int amount)
        {
            bool enoughSpace = _currentLoad + amount*goods.Volume <= _capacity;

            if(enoughSpace)
            {
                for (int i = 0; i<amount;i++)
                {
                    _goods.Add(goods);
                }
            }
            else
            {
                Console.WriteLine($"Not enough space to buy {amount} product(s)! Current load is {_currentLoad}. Capacity is {_capacity}");
            }
        }

        public static void BuyGoods()
        {

        }

    }
}
