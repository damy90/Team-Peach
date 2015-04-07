namespace Models
{
    using Models.Foods;
    public class FishMeat : Meat, IBuyable
    {
        public FishMeat()
        {
        }
        public FishMeat(int foodValue)
            : base(foodValue)
        {
        }
        public int Price
        {
            get { return PricesConstants.FishMeatPrice; }
        }
    }
}
