namespace Models
{
    using Models.Foods;
    public class Pear : Plant, IBuyable
    {
        public Pear()
            : base(5)
        {
        }
        public int Price
        {
            get { return PricesConstants.PearPrice; }
        }
    }
}
