namespace Models
{
    public abstract class Food
    {
        public Food()
        {
        }
        public Food(int foodValue, int feedInterval)
        {
            this.FoodValue = foodValue;
            this.FeedInterval = feedInterval;
        }
        //The increase in Feed
        public int FoodValue { get; set; }
        //The time until the same food can be given to the animaml in seconds
        public int FeedInterval { get; set; }
    }
}
