namespace Models
{
    public abstract class Meat : Food
    {
        //Logic for increasing Meat's food value
        public void Cook(int cookTime)
        {
            var foodValue = base.FoodValue;
            base.FeedInterval += cookTime; //Cannot give the same food to the animal until it is done cooking.

            /*
             *If the cooking time is bigger than the value of the food, remove half of the difference between them from the value.
             *Else add half of the cooking time to the value of the food. This way if the meat's value can be increased only by half
             *and there are negative effects to overcooking the meat.
            */

            if (cookTime > foodValue)
            {
                base.FoodValue -= (cookTime - foodValue) / 2;
                if (base.FoodValue < 0) //if the value of the food is negative, make the value 0 (does not increase feed)
                {
                    base.FoodValue = 0;
                }
            }
            else
            {
                base.FoodValue += cookTime / 2;
            }
        }
    }
}
