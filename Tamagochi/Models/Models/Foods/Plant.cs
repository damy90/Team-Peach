namespace Models
{
    public abstract class Plant : Food
    {
        public Plant()
        {
        }
        public Plant(int foodValue)
            : base(foodValue)
        {
        }

        ////How much the the plant can grow (the biggest increase possible in foodValue)
        //public int GrowthPotential { get; set; }
        ////Logic for increasing the Plant's food value
        //public void GrowBigger(int growthTime)
        //{
        //    var foodValue = base.FoodValue;
        //    base.FeedInterval += growthTime; //Cannot give the same plant to the animal until the plant is done growing.

        //    /*
        //     *If the growth time is bigger than the plant's potential, remove points from the food value (the plant rottens).
        //     *Else add point to foodValue, equal to growth time.
        //    */
        //    if (growthTime > this.GrowthPotential)
        //    {
        //        base.FoodValue -= growthTime - this.GrowthPotential;
        //        if (base.FoodValue < 0)
        //        {
        //            base.FoodValue = 0;
        //        }
        //    }
        //    else
        //    {
        //        base.FoodValue += growthTime;
        //    }
        //}
    }
}
