namespace Models
{
    using Models.Foods;
    public class Steak : Meat, IBuyable
    {
        public Steak()
        {
        }
        public Steak(int foodValue)
            : base(foodValue)
        {
        }
        public int Price
        {
            get { return PricesConstants.SteakPrice; }
        }
    }
}
