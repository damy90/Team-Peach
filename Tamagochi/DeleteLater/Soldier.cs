using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteLater
{
    public class Soldier : IPerson
    {

        private gender gendy;
        private int agey;

        public Soldier(gender gend, int age)
        {
            this.gender = gend;
            this.age = age;
        }

        public gender gender
        {
            get
            {
                return this.gendy;
            }
            set
            {
                this.gendy = value;
            }
        }

        public int age
        {
            get
            {
                return this.agey;
            }
            set
            {
                this.agey = value;
            }
        }
    }
}
