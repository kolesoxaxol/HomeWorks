using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Products;
using ValidationDll;

namespace Management.ProductsLibrary
{
    public static class Market
    {
        internal static int _goodsAmount;

        private static Dictionary<int, string> _namesList;

        private static Dictionary<int, Goods[]> _goodsList;

        private static List<Action> _showGoods;

        static Market()
        {
            _goodsAmount = 3;

            _namesList = new Dictionary<int, string>(_goodsAmount);

            _goodsList = new Dictionary<int, Goods[]>(_goodsAmount);

            _showGoods = new List<Action>();

            _namesList.Add(0, "Sand");
            _namesList.Add(1, "Cement");
            _namesList.Add(2, "Screw");

            _goodsList.Add(0, SandLibrary.GetSand() );
            _goodsList.Add(1, CementLibrary.GetCement() );
            _goodsList.Add(2, ScrewLibrary.GetScrew() );

            _showGoods.Add( () => SandLibrary.ShowSand() );
            _showGoods.Add( () => CementLibrary.ShowCement() );
            _showGoods.Add( () => ScrewLibrary.ShowScrew() );
        }

        public static void ShowGoodsList()
        {
            for (int i = 0; i < _goodsAmount; i++)
            {
                Console.WriteLine($"N: {i}, {_namesList[i]}");
            }
        }
        public static void ShowSpecificGoods()
        {
            string request = "Select a number from the list what goods you want to browse:";

            int input = Input.Validation(_goodsAmount-1, request);

            _showGoods[input]();
        }
        public static int SelectSpecificGoods()
        {
            string request = "Select a number from the list what goods you want to browse:";

            int input = Input.Validation(_goodsAmount-1, request);

            _showGoods[input]();

            return input;
        }

        public static Goods[] GetGoodsList(int index)
        {
            return _goodsList[index];
        }

    }
}
