using Models.Models.Foods;

namespace Models
{
    using System;
    public static class FoodFactory
    {
        public static Food CreateFood(string foodName)
        {
            switch (foodName.ToLower())
            {
                case "banana":
                    return new Banana();
                case "drumstick":
                    return new Drumstick();
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
