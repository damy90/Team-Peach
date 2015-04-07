namespace Models
{
    using System;
    using System.Collections.Generic;

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

        public List<string> FoodsInStore
        {
            get
            {
                return new List<string> { "Banana", "Pear", "FishMeat", "Pizza", "Steak" };
            }
        }

        private IBuyable GetFood(string foodName)
        {
            Random rand = new Random();
            int foodValue = rand.Next(1, 15);

            IBuyable createdFood =  FoodFactory.CreateFood(foodName, foodValue);
            return createdFood;
        }

        public void BuyItem(string item, Player buyer)
        {
            var food = this.GetFood(item);
            if (food.Price <= buyer.Coins)
            {
                buyer.Coins -= food.Price;
                buyer.AddItem(food);
            }
        }
    }
}
