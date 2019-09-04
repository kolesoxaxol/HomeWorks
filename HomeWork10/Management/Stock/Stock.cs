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

        //Method to add one specific good.

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

        //Method to remove one specific good.

        static void RemoveGoods(Goods goods, int amount)
        {

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

        //Buying goods.

        public static void BuyGoods()
        {
            //getting names of goods classes (Sand, Screw, etc.) from the market
            ProductsLibrary.Market.ShowGoodsList();

            //showing all avilable products of specific class
            int typeSelection = ProductsLibrary.Market.SelectSpecificGoods();

            string request = "Select number of product you want to buy.";

            //selection of one specific product
            int goodSelection = Input.Validation(ProductsLibrary.Market._goodsAmount, request);

            request = "How many units do you want to buy?";

            int amountCanBuy = Int32.MaxValue;

            //selecting amount of product
            int amount = Input.Validation(amountCanBuy, request);

            Goods selectedGoods = ProductsLibrary.Market.GetGoodsList(typeSelection)[goodSelection];

            AddGoods(selectedGoods, amount);
        }

        public static void SellGoods()
        {

            ShowStock();

            //getting current stock stance and amount of duplicates per each good

            int[] duplicates;

            Goods[] goodsList = GetStock(out duplicates);

            //check for empty stock

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

            //for each element in stock I check it's own expiration date and how long it takes till it expires. After that I compare results with current date.

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
            //due to the fact I work with a List<Goods>, i may have duplicate items in the stock.
            //To solve it I build Dictionary of duplicates and List of all items without duplicates

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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"N: {indexCount}, Amount: {duplicatesStock[goods]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"N: {indexCount}, Amount: {1}");
                        Console.ResetColor();
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

        //Simillar as with show stock: I have to deal with duplicates and I've selected the same method.
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
