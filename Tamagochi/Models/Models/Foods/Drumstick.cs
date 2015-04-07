using Models.Models.Foods;

namespace Models
{
    public class Drumstick : Meat, IBuyable
    {
        private const int price = PricesConstants.DrumstickPrice;

        public Drumstick()
            : base(price/2)
        {
        }

        public int Price
        {
            get { return PricesConstants.DrumstickPrice; }
        }
    }
}
