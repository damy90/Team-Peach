using System;

namespace Models
{
    public struct Condition
    {
        private int happiness;
        private int feed;
        private int cleanliness;
        private int energy;

        public Condition(int initialValue)
            : this()
        {
            if (initialValue > 100)
            {
                initialValue = 100;
            }

            if (initialValue < 1)
            {
                initialValue = 1;
            }

            happiness = initialValue;
            feed = initialValue;
            cleanliness = initialValue;
            energy = initialValue;
        }

        public int Happiness
        {
            get
            {
                return this.happiness;
            }
            set
            {
                this.happiness = ChangeCondition(0, value);
            }
        }

        public int Feed
        {
            get
            {
                return this.feed;
            }
            set
            {
                this.feed = ChangeCondition(0, value);
            }
        }

        public int Cleanliness
        {
            get
            {
                return this.cleanliness;
            }
            set
            {
                this.cleanliness = ChangeCondition(0, value);
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                this.energy=ChangeCondition(0, value);
            }
        }

        private int ChangeCondition(int conditionValue, int increment)
        {
            conditionValue = Math.Min(conditionValue + increment, 100);
            conditionValue = Math.Max(conditionValue, 0);
            return conditionValue;
        }

        public void ChangeHappiness(int increment)
        {
            //int oldValueHappiness = this.Happiness;
            this.happiness = ChangeCondition(this.happiness, increment);
            //Happiness relation to energy
            //this.Energy = ChangeCondition(this.Energy, (oldValueHappiness - this.Happiness) / 4);
        }

        public void ChangeEnergy(int increment)
        {
            //int oldValueEnergy = this.Energy;
            this.energy = ChangeCondition(this.energy, increment);
            //Energy relation to happiness
            //this.Happiness = ChangeCondition(this.Happiness, (oldValueEnergy - this.Energy) / 8);
        }

        public void ChangeCleanliness(int increment)
        {
            //int oldValueCleanliness = this.Cleanliness;
            this.cleanliness = ChangeCondition(this.cleanliness, increment);
            //Energy Cleanliness to happiness
            //this.Happiness = ChangeCondition(this.Happiness, (oldValueCleanliness - this.Cleanliness) / 8);
        }

        public void ChangeFeed(int increment)
        {
            //int oldValueFeed = this.Feed;
            this.feed = ChangeCondition(this.feed, increment);
            //Feed relation to happiness and energy
            //this.Happiness = ChangeCondition(this.Happiness, (oldValueFeed - this.Feed) / 8);
            //this.Energy = ChangeCondition(this.Energy, (oldValueFeed - this.Feed) / 3);
        }
    }
}
