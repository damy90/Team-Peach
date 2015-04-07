namespace Models
{
    using System;
    public abstract class Food
    {
        private int foodValue;
        public Food()
        {
        }
        public Food(int foodValue)
        {
            this.FoodValue = foodValue;
        }

        //The increase in Feed
        public virtual int FoodValue
        {
            get { return this.foodValue; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Food value cannot be less than or equal to 0!");
                }
                this.foodValue = value;
            }
        }

        ////The time until the same food can be given to the animaml in seconds
        //public int FeedInterval { get; set; }
    }
}
