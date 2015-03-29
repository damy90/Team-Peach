using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.Animals
{
    public class Carp : Fish, IHerbivorous
    {
        #region Fileds
        private List<Plant> plantsFoodAllowed = new List<Plant>();
        #endregion

        #region Constructors
        public Carp()
            : base()
        {
        }

        public Carp(Gender  sex, string name)
            : base(sex, name)
        {
        }

        public Carp(Gender  sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }
        #endregion

        public List<Plant> PlantFoodAllowed
        {
            get { return this.plantsFoodAllowed; }
        }
    }
}
