namespace Models
{
    using Models.Foods;
    public class FishMeat : Meat, IBuyable
    {
        public FishMeat()
            : base(PricesConstants.FishMeatPrice/2)
        {
        }
        public int Price
        {
            get { return PricesConstants.FishMeatPrice; }
        }
    }
}
