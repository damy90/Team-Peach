namespace Models
{
    using System;
    public static class FoodFactory
    {
        public static IBuyable CreateFood(string foodName, int foodValue)
        {
            switch (foodName.ToLower())
            {
                case "banana":
                    return new Banana(foodValue);
                case "fishmeat":
                    return new FishMeat(foodValue);
                case "pear":
                    return new Pear(foodValue);
                case "pizza":
                    return new Pizza(foodValue);
                case "steak":
                    return new Steak(foodValue);
                default:
                    throw new ArgumentException("This food does not exist!");
            }
        }
    }
}
