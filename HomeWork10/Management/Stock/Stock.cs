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
            bool enoughSpace = _currentLoad + amount * goods.Volume <= _capacity;

            if (enoughSpace)
            {
                for (int i = 0; i < amount; i++)
                {
                    _goods.Add(goods);
                    _currentLoad += goods.Volume;
                }

                Console.WriteLine($"Success! {amount} products(s) of {goods.Name} were added to the stock.");
            }
            else
            {
                Console.WriteLine($"Not enough space to buy {amount} product(s)! Current load is {_currentLoad}. Capacity is {_capacity}");
            }
        }

        static void RemoveGoods(Goods goods, int amount)
        {

            var tempStock = _goods.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                  .ToDictionary(x => x.Key, y => y.Count());

            bool goodsExist = tempStock[goods] > 0;

            bool enoughGoods = tempStock[goods] - amount > 0;

            if(!goodsExist)
            {
                Console.WriteLine("You don't have this goods at Stock.");
            }
            else if(!enoughGoods)
            {
                Console.WriteLine($"Not enough goods! You've selected {amount} product(s), but there are only {tempStock[goods]} left.");
            }
            else
            {
                for(int i = 0;i<amount;i++)
                {
                    _goods.Remove(goods);
                    _currentLoad -= goods.Volume;
                }

                Console.WriteLine($"Success! {amount} products(s) of {goods.Name} were removed from the stock.");
            }
        }

        public static void BuyGoods()
        {
            ProductsLibrary.Market.ShowGoodsList();

            int typeSelection = ProductsLibrary.Market.SelectSpecificGoods();

            Console.WriteLine("Select number of product you want to buy");

            int goodSelection = int.Parse(Console.ReadLine());

            Console.WriteLine("How many units do you want to buy?");

            int amount = int.Parse(Console.ReadLine());

            Goods selectedGoods = ProductsLibrary.Market.GetGoodsList(typeSelection)[goodSelection];

            AddGoods(selectedGoods, amount);
        }

        public static void SellGoods()
        {
            ProductsLibrary.Market.ShowGoodsList();

            int typeSelection = ProductsLibrary.Market.SelectSpecificGoods();

            Console.WriteLine("Select number of product you want to buy");

            int goodSelection = int.Parse(Console.ReadLine());

            Console.WriteLine("How many units do you want to buy?");

            int amount = int.Parse(Console.ReadLine());

            Goods selectedGoods = ProductsLibrary.Market.GetGoodsList(typeSelection)[goodSelection];

            RemoveGoods(selectedGoods, amount);
        }

    }
}
