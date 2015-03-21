using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Shop
    {
        public Shop()
        {

        }

        public void BuyItem(IBuyable item, Player buyer)
        {
            if (item.Price <= buyer.Coins)
            {
                buyer.Coins -= item.Price;
                buyer.AddItem(item);
            }
        }
    }
}
