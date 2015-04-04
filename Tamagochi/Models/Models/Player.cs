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

        private int coins;
        private Animal pet;


        public Player(Animal animal)
        {
            this.coins = StartCoins;

            this.Pet = animal;
            this.Points = 0;
            this.AvailableFood = new List<Food>(){new Pizza()};
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

        //public List<IBuyable> Food
        //{
        //    get
        //    {
        //        return new List<IBuyable>(this.food);
        //    }
        //    private set
        //    {
        //        ;
        //    }
        //}

        //public void AddItem(IBuyable item)
        //{
        //    this.Food.Add(item);
        //}

        //cannot be tested until a game can be started
        //public void Serialize(string path = "../../")
        //{
        //    XmlSerializer xml = new XmlSerializer(this.GetType());
        //    StreamWriter file = new StreamWriter(path + this.name + ".xml");
        //    xml.Serialize(file, this);
        //    file.Close();
        //}

        //public Player Deserialize(string path = "../../player.xml")
        //{
        //    XmlSerializer xml = new XmlSerializer(this.GetType());
        //    StreamReader file = new StreamReader(path);
        //    _instance = (Player)xml.Deserialize(file);
        //    file.Close();
        //    return _instance;
        //}

        public int Points { get; set; }
    }
}
