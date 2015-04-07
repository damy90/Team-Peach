namespace Models
{
    using Models.Foods;
    public class FishMeat : Meat, IBuyable
    {
        public int Price
        {
            get { return PricesConstants.FishMeatPrice; }
        }
    }
}
