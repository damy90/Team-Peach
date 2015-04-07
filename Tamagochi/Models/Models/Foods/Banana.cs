namespace Models
{
    using Models.Foods;

    public class Banana : Plant, IBuyable
    {
        public Banana()
        {
        }
        public Banana(int foodValue)
            : base(foodValue)
        {
        }
        public int Price
        {
            get { return PricesConstants.BananaPrice; }
        }
    }
}
