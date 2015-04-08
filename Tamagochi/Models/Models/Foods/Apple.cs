using Models.Models.Foods;

namespace Models
{
    public class Apple : Plant, IBuyable
    {
        public Apple()
        {
        }
        public Apple(int foodValue)
            : base(foodValue)
        {
        }

        public int Price
        {
            get { return PricesConstants.ApplePrice; }
        }
    }
}
