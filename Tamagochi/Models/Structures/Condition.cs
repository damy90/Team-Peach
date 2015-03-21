using System;

namespace Models
{
    public struct Condition
    {
        public int Happiness { get; private set; }
        public int Feed { get; private set; }
        public int Cleanliness { get; private set; }
        public int Energy { get; private set; }

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

            Happiness = initialValue;
            Feed = initialValue;
            Cleanliness = initialValue;
            Energy = initialValue;
        }

        private int ChangeCondition(int conditionValue, int increment)//example input: Condidion.Feed
        {
            conditionValue = Math.Min(conditionValue + increment, 100);
            conditionValue = Math.Max(conditionValue, 0);
            return conditionValue;
        }

        public void ChangeHappiness(int increment)
        {
            int oldValueHappiness = this.Happiness;
            this.Happiness = ChangeCondition(this.Happiness, increment);
            //Happiness relation to energy
            this.Energy = ChangeCondition(this.Energy, (oldValueHappiness - this.Happiness) / 4);
        }

        public void ChangeEnergy(int increment)
        {
            int oldValueEnergy = this.Energy;
            this.Energy = ChangeCondition(this.Energy, increment);
            //Energy relation to happiness
            this.Happiness = ChangeCondition(this.Happiness, (oldValueEnergy - this.Energy) / 8);
        }

        public void ChangeCleanliness(int increment)
        {
            int oldValueCleanliness = this.Cleanliness;
            this.Cleanliness = ChangeCondition(this.Cleanliness, increment);
            //Energy Cleanliness to happiness
            this.Happiness = ChangeCondition(this.Happiness, (oldValueCleanliness - this.Cleanliness) / 8);
        }

        public void ChangeFeed(int increment)
        {
            int oldValueFeed = this.Feed;
            this.Feed = ChangeCondition(this.Feed, increment);
            //Feed relation to happiness and energy
            this.Happiness = ChangeCondition(this.Happiness, (oldValueFeed - this.Feed) / 8);
            this.Energy = ChangeCondition(this.Energy, (oldValueFeed - this.Feed) / 3);
        }
    }
}
