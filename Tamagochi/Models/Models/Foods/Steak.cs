namespace Models
{
    using Models.Foods;
    public class Steak : Meat, IBuyable
    {
        public int Price
        {
            get { return PricesConstants.SteakPrice; }
        }
    }
}
