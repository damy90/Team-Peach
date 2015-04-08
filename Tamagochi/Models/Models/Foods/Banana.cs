namespace Models
{
    using Models.Foods;

    public class Banana : Plant, IBuyable
    {
        public Banana()
            : base(PricesConstants.BananaPrice/2)
        {
        }
        public int Price
        {
            get { return PricesConstants.BananaPrice; }
        }
    }
}
