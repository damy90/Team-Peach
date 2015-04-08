namespace Models
{
    using Models.Foods;
    public class Pear : Plant, IBuyable
    {
        public Pear()
            : base(PricesConstants.PearPrice/2)
        {
        }
        public int Price
        {
            get { return PricesConstants.PearPrice; }
        }
    }
}
