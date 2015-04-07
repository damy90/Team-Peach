namespace Models
{
    using Models.Foods;
    public class Pear : Plant, IBuyable
    {
        public int Price
        {
            get { return PricesConstants.PearPrice; }
        }
    }
}
