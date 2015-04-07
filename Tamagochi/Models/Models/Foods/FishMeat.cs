namespace Models
{
    using Models.Foods;
    public class FishMeat : Meat, IBuyable
    {
        public FishMeat()
            : base(6)
        {
        }
        public int Price
        {
            get { return PricesConstants.FishMeatPrice; }
        }
    }
}
