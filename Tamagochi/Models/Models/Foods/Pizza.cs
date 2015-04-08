namespace Models
{
    using Models.Foods;
    public class Pizza : Meat, IBuyable
    {
        public Pizza()
            : base(PricesConstants.PizzaPrice/2)
        {
        }
        public int Price
        {
            get { return PricesConstants.PizzaPrice; }
        }
    }
}
