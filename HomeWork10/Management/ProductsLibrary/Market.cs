using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Products;

namespace Management.ProductsLibrary
{
    public static class Market
    {
        private static int _goodsAmount;

        private static Dictionary<int, string> _namesList;

        private static Dictionary<int, Goods[]> _goodsList;

        private static List<Action> _showGoods;

        static Market()
        {
            _goodsAmount = 3;

            _namesList = new Dictionary<int, string>(_goodsAmount);

            _goodsList = new Dictionary<int, Goods[]>(_goodsAmount);

            _showGoods = new List<Action>();

            _namesList.Add(1, "Sand");
            _namesList.Add(2, "Cement");
            _namesList.Add(3, "Screw");

            _goodsList.Add(1, SandLibrary.GetSand() );
            _goodsList.Add(2, CementLibrary.GetCement() );
            _goodsList.Add(3, ScrewLibrary.GetScrew() );

            _showGoods.Add( () => SandLibrary.ShowSand() );
            _showGoods.Add( () => CementLibrary.ShowCement() );
            _showGoods.Add( () => ScrewLibrary.ShowScrew() );
        }

        public static void ShowGoodsList()
        {
            for (int i = 1; i <= _goodsAmount; i++)
            {
                Console.WriteLine($"N: {i}, {_namesList[i]}");
            }
        }

        public static int SelectSpecificGoods()
        {
            Console.WriteLine("Select a number from the list what goods you want to browse:");

            int input = int.Parse(Console.ReadLine());

            _showGoods[input]();

            return input;
        }

        public static Goods[] GetGoodsList(int index)
        {
            return _goodsList[index];
        }
    }
}
