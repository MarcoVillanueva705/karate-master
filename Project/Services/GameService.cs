using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
    public class GameService : IGameService
    {
        private IGame _game { get; set; }

        public List<string> Messages { get; set; }
        public GameService()
        {
            _game = new Game();
            Messages = new List<string>();
        }
        public void StartGame()
        {
            Messages.Add("Welcome to the 4 Chambers!");
        }
        public void Go(string direction)
        {
            if (_game.CurrentRoom.Exits.ContainsKey(direction))
            {
                Console.Clear();
                _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
            }
        }
        public void Help()
        {
            Messages.Add("To start the game, type START in the console. ");
            var input = Console.ReadLine().ToUpper();
            Console.Clear();
        }

        public void Inventory()
        {
        Item nunchucks = new Item("Nunchucks", "Use these to defeat the Boss!");
        Messages.Add("------INVENTORY-------");
        Messages.Add($"{nunchucks.ItemName}"); 
        Messages.Add("press any key to return");

        }  

        public void Look()
        {
            throw new System.NotImplementedException();
        }

        public void Quit()
        {
            throw new System.NotImplementedException();
        }
        ///<summary>
        ///Restarts the game 
        ///</summary>
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public void Setup(string playerName)
        {
            throw new System.NotImplementedException();
        }
        ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
        public void TakeItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
        ///<summary>
        ///No need to Pass a room since Items can only be used in the CurrentRoom
        ///Make sure you validate the item is in the room or player inventory before
        ///being able to use the item
        ///</summary>
        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
    }
}
