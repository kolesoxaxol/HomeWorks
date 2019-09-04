using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Products;
using ValidationDll;

namespace Management.Stock
{

    public static class Stock
    {
        private static List<Goods> _goods;

        private static int _capacity = 1000;

        private static int _currentLoad = 0;


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

            var stockNoDuplicates = _goods.Distinct().ToList();

            bool goodsExist = stockNoDuplicates.Count > 0;

            if (!goodsExist)
            {
                Console.WriteLine("You don't have this goods at Stock.");
            }
            else
            {
                for (int i = 0; i < amount; i++)
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

            string request = "Select number of product you want to buy.";

            int goodSelection = Input.Validation(ProductsLibrary.Market._goodsAmount, request);

            request = "How many units do you want to buy?";

            int amountCanBuy = Int32.MaxValue;

            int amount = Input.Validation(amountCanBuy, request);

            Goods selectedGoods = ProductsLibrary.Market.GetGoodsList(typeSelection)[goodSelection];

            AddGoods(selectedGoods, amount);
        }

        public static void SellGoods()
        {
            ShowStock();

            int[] duplicates;

            Goods[] goodsList = GetStock(out duplicates);

            bool stockIsEmpty = goodsList == null;

            if(!stockIsEmpty)
            {

                string request = "Select number of product you want to sell.";

                int goodSelection = Input.Validation(goodsList.Length, request);

                request = "How many units do you want to sell?";

                int amountCanBuy = duplicates[goodSelection];

                int amount = Input.Validation(amountCanBuy, request);

                Goods selectedGoods = goodsList[goodSelection];

                RemoveGoods(selectedGoods, amount);
            }

        }


        public static List<Goods> ExpiredGoods()
        {
            List<Goods> expiredGoods = new List<Goods>();

            foreach (Goods goods in _goods)
            {
                DateTime expirationDate = goods.DateOfProduction + goods.ExpirationTime;

                DateTime today = DateTime.Now;

                bool expired = expirationDate < today;

                if (expired)
                {
                    expiredGoods.Add(goods);
                }
            }

            int amountOfExpired = expiredGoods.Count;

            Console.WriteLine($"There is(are) {amountOfExpired} expired good(s).");

            bool anyExpired = amountOfExpired > 0;

            if (anyExpired)
            {
                Console.WriteLine($"List of expired goods:");

                foreach (Goods goods in expiredGoods)
                {
                    DateTime expirationDate = goods.DateOfProduction + goods.ExpirationTime;

                    Console.WriteLine($"Name: {goods.Name}, Price: {goods.Price}, Volume: {goods.Volume}, Expiration date: {expirationDate}");
                }
            }

            return expiredGoods;
        }

        public static void RemoveExpiredGoods()
        {
            List<Goods> expiredGoods = ExpiredGoods();

            if (expiredGoods != null)
            {
                foreach (Goods goods in expiredGoods)
                {
                    _goods.Remove(goods);
                    _currentLoad -= goods.Volume;
                }
            }
        }


        public static void ShowStock()
        {
            var duplicatesStock = _goods.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                  .ToDictionary(x => x.Key, y => y.Count());

            var stockNoDuplicates = _goods.Distinct().ToList();

            bool goodsAreInStock = stockNoDuplicates.Count > 0;

            int indexCount = 0;

            if (goodsAreInStock)
            {
                foreach(Goods goods in stockNoDuplicates)
                {
                    bool goodHasDuplicate = duplicatesStock.Any(key=>key.Key.Equals(goods));

                    if(goodHasDuplicate)
                    {
                        Console.Write($"N: {indexCount}, Amount: {duplicatesStock[goods]}");
                    }
                    else
                    {
                        Console.Write($"N: {indexCount}, Amount: {1}");
                    }

                    goods.LogProperties();
                    Console.WriteLine("======================");

                    indexCount++;
                }
            }
            else
            {
                Console.WriteLine("\nThe stock is empty!\n");
            }

        }

        public static Goods[] GetStock(out int[] duplicates)
        {
            var duplicatesStock = _goods.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                  .ToDictionary(x => x.Key, y => y.Count());

            var stockNoDuplicates = _goods.Distinct().ToList();

            bool goodsAreInStock = stockNoDuplicates.Count > 0;

            if (goodsAreInStock)
            {
                int amountOfGoods = stockNoDuplicates.Count;

                Goods[] tempStock = new Goods[amountOfGoods];
                var dupl = new int[amountOfGoods];

                for(int i = 0;i< amountOfGoods;i++)
                {
                    tempStock[i] = stockNoDuplicates[i];

                    bool goodHasDuplicate = duplicatesStock.Any(key => key.Key.Equals(stockNoDuplicates[i]));

                    if(goodHasDuplicate)
                    {
                        dupl[i] = duplicatesStock[stockNoDuplicates[i]];
                    }
                    else
                    {
                        dupl[i] = 1;
                    }


                    
                }
                duplicates = dupl;
                return tempStock.ToArray();
            }
            else
            {
                duplicates = null;
                return null;
            }

        }
    }
}
