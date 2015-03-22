using System;
using System.Collections.Generic;

namespace Models
{
    //singleton (only one player can be initialized)
    public sealed class Player
    {
        const int StartCoins = 500;

        private string name;
        private int coins;
        private Animal pet;
        private List<IBuyable> food;
        private static Player _instance;

        private Player(string name, Animal animal)
        {
            this.coins = StartCoins;
            this.name = name;
            this.pet = animal;
            this.food = new List<IBuyable>();
        }

        //this singleton is somewhat ugly and unusual
        public static Player Initialize(string name, Animal animal)
        {
            if (_instance == null)
            {
                return _instance = new Player(name, animal);
            }

            throw new InvalidOperationException("A player already exists!");
        }

        public static Player GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    throw new ArgumentNullException("No player has been initialized!");
                }

                return _instance;
            }
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
