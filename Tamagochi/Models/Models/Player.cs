using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

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

        private Player()
        {

        }

        private Player(string name, Animal animal)
        {
            this.coins = StartCoins;
            this.name = name;
            this.pet = animal;
            this.food = new List<IBuyable>();
        }

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

        //cannot be tested until a game can be started
        public void Serialize(string path = "../../")
        {
            XmlSerializer xml = new XmlSerializer(this.GetType());
            StreamWriter file = new StreamWriter(path + this.name + ".xml");
            xml.Serialize(file, this);
            file.Close();
        }

        public Player Deserialize(string path = "../../player.xml")
        {
            XmlSerializer xml = new XmlSerializer(this.GetType());
            StreamReader file = new StreamReader(path);
            _instance = (Player)xml.Deserialize(file);
            file.Close();
            return _instance;
        }
    }
}
