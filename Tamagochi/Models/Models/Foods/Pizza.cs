namespace Models
{
    using Models.Foods;
    public class Pizza : Meat, IBuyable
    {
        public Pizza()
        {
        }
        public Pizza(int foodValue)
            : base(foodValue)
        {
        }
        public int Price
        {
            get { return PricesConstants.PizzaPrice; }
        }
    }
}
