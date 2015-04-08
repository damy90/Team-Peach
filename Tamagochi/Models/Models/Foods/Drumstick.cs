using Models.Models.Foods;

namespace Models
{
    public class Drumstick : Meat, IBuyable
    {
        public Drumstick()
            : base(PricesConstants.DrumstickPrice/2)
        {
        }

        public int Price
        {
            get { return PricesConstants.DrumstickPrice; }
        }
    }
}
