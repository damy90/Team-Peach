using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace Models
{
    public class Player
    {
        const int StartCoins = 100;

        private int points;
        private int coins;
        private Animal pet;
        
        public Player(Animal animal)
        {
            this.coins = StartCoins;
            this.Pet = animal;
            this.Points = 0;
            this.AvailableFood = new List<Food>(){new Pizza()};
        }

        public int Points {
            get { return this.points; }
            set { this.points = value; }
        }

        //public
        
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
            private set { this.pet = value; }
        }

        public void AddPoints(int points)
        {
            this.Points += points;
        }

        public void ChangeCoins(int coins)
        {
            this.Coins += coins;
        }

        //public Player Deserialize(string path = "../../player.xml")
        //{
        // TODO: Dani, make this happen
        //    XmlSerializer xml = new XmlSerializer(this.GetType());
        //    StreamReader file = new StreamReader(path);
        //    _instance = (Player)xml.Deserialize(file);
        //    file.Close();
        //    return _instance;
        //}

        public IList<Food> AvailableFood { get; private set; }

        public void RemoveFood(string eaten)
        {
            var foodToRemove = AvailableFood.FirstOrDefault(x => x.GetType().Name == eaten);
            AvailableFood.Remove(foodToRemove);
        }
    }
}
