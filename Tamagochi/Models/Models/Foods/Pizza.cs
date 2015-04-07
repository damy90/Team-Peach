namespace Models
{
    using Models.Foods;
    public class Pizza : Meat, IBuyable
    {
        public int Price
        {
            get { return PricesConstants.PizzaPrice; }
        }
    }
}
