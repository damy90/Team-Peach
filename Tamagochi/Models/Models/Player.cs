using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using Models.Models.Foods;
using Polenter.Serialization;

namespace Models
{
    public class Player
    {
        const int StartCoins = 100;

        private int coins;
        private Animal pet;

        public Player()
        {

        }

        public Player(Animal animal)
        {
            this.coins = StartCoins;

            this.Pet = animal;
            this.Points = 0;
            this.AvailableFood = new List<Food>(){new Bread()};
        }

        public int Coins
        {
            get
            {
                return Math.Max(coins, 0);
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

        public int Points { get; set; }

        internal void AddItem(Food food)
        {
            this.AvailableFood.Add(food);
        }

        #region Serialization
        public void Serialize(string path = "../../savedgame.xml")
        {
            var serializer = new SharpSerializer();
            serializer.Serialize(this, path);
        }

        public static Player Deserialize(string path = "../../Saved Game.xml")
        {
            var serializer = new SharpSerializer();
            return (Player)serializer.Deserialize(path); ;
        }

        #endregion
    }
}
