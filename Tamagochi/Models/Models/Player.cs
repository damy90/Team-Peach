using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

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
        }

        public int Points {
            get { return this.points; }
            set { this.points = value; }
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
            private set { this.pet = value; }
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
    }
}
