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
                    return new Banana();
                case "fishmeat":
                    return new FishMeat();
                case "pear":
                    return new Pear();
                case "pizza":
                    return new Pizza();
                case "steak":
                    return new Steak();
                default:
                    throw new ArgumentException("This food does not exist!");
            }
        }
    }
}
