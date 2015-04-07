namespace Models
{
    using Models.Foods;
    public class Pear : Plant, IBuyable
    {
        public Pear()
        {
        }
        public Pear(int foodValue)
            : base(foodValue)
        {
        }
        public int Price
        {
            get { return PricesConstants.PearPrice; }
        }
    }
}
