using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Player
    {
        const int StartCoins = 500;

        private string name;
        private int coins;
        private Animal pet;
        private List<IBuyable> food;

        public Player(string name, Animal animal)
        {
            this.coins = StartCoins;
            this.name = name;
            this.pet = animal;
            this.food = new List<IBuyable>();
        }

        public int Coins
        {
            get
            {
                return this.coins;
            }
            set
            {
                this.coins = value;
            }
        }

        public Animal Pet
        {
            get
            {
                return this.pet;
            }
        }

        public List<IBuyable> Food
        {
            get
            {
                return new List<IBuyable>(this.food);
            }
            private set
            {
                ;
            }
        }

        public void AddItem(IBuyable item)
        {
            this.Food.Add(item);
        }

    }
}
