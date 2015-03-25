using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Animal
    {
        private const int MaxValue = 100;

        private Condition initialCondition;
        private Gender sex;
        private string name;
        protected readonly Random random;

        public Animal(Gender sex, string name)
        {
            this.Name = name;
            this.sex = sex;
            this.initialCondition = new Condition(MaxValue);
            if (this is ICarnivorous)
                random = new Random();
        }

        public Animal(Gender sex, string name, Condition initialCondition)
            : this(sex, name)
        {
            this.initialCondition = initialCondition;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public Condition CurrentCondition
        {
            get
            {
                return this.initialCondition;
            }
            set
            {
                this.initialCondition = value;
            }
        }

    }
}
