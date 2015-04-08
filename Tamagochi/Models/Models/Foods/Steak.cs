namespace Models
{
    using Models.Foods;
    public class Steak : Meat, IBuyable
    {
        public Steak()
            : base(PricesConstants.SteakPrice/2)
        {
        }
        public int Price
        {
            get { return PricesConstants.SteakPrice; }
        }
    }
}
