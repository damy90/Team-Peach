namespace Models
{
    using System;
    using System.Collections.Generic;

    public class Shop
    {
        private static Shop _instance;

        private Shop()
        {
            this.FoodsInStore = new List<Food>();
        }

        public static Shop Instance()
        {
            if (_instance == null)
            {
                _instance = new Shop();
            }

            return _instance;
        }

        public List<Food> FoodsInStore { get; private set; }

        private Food GetFood(string foodName)
        {
            Food createdFood =  FoodFactory.CreateFood(foodName);
            return createdFood;
        }

        public void BuyItem(string item, Player buyer)
        {
            var food = this.GetFood(item);
            if ((food as IBuyable).Price <= buyer.Coins)
            {
                buyer.Coins -= (food as IBuyable).Price;
                buyer.AddItem(food);
            }
        }

        public void LoadStore(IAnimal animal)
        {
            if (animal is ICarnivorous)
            {
                this.FoodsInStore.AddRange((animal as ICarnivorous).MeatFoodAllowed);
            }
            else
            {
                this.FoodsInStore.AddRange((animal as IHerbivorous).PlantsFoodAllowed);
            }
        }
    }
}
