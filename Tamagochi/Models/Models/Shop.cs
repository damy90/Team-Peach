using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Shop
    {
        private static Shop _instance;

        private Shop()
        {

        }

        public static Shop Instance()
        {
            if (_instance == null)
            {
                _instance = new Shop();
            }

            return _instance;
        }

        //public void BuyItem(IBuyable item, Player buyer)
        //{
        //    if (item.Price <= buyer.Coins)
        //    {
        //        buyer.Coins -= item.Price;
        //        buyer.AddItem(item);
        //    }
        //}
    }
}
