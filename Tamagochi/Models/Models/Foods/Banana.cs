namespace Models
{
    using Models.Foods;

    public class Banana : Plant, IBuyable
    {
        public int Price
        {
            get { return PricesConstants.BananaPrice; }
        }
    }
}
