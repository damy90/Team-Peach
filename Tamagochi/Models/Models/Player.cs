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

        public Player(string name, Animal animal)
        {
            this.coins = StartCoins;
            this.name = name;
            this.pet = animal;
        }

    }
}
