using Models.Models.Foods;

namespace Models
{
    public class Apple : Plant, IBuyable
    {
        public Apple()
        {
        }
        public Apple(int foodValue)
            : base(PricesConstants.ApplePrice/2)
        {
        }

        public int Price
        {
            get { return PricesConstants.ApplePrice; }
        }
    }
}
