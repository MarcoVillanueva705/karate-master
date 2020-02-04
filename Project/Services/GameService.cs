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
        public bool GameOver { get; set; } = false;
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
                Messages.Add($"You are now in the {_game.CurrentRoom.Name}: {_game.CurrentRoom.Description}");

                //FIXME itterate over CurrentRoom.Items and print each item//DONE
                foreach (Item i in _game.CurrentRoom.Items)
            {
                Messages.Add($"{i.ItemName}");
            }
            }
            //NOTE add message for invalid directoin
        }
        public void Help()
        {
            Messages.Add("To start the game, type START in the console. ");
            Console.Clear();
        }

        public void Inventory()
        {
        Item nunchucks = new Item("Nunchucks", "Use these to defeat the Boss!");
        Item katana = new Item("Katana", "Slice and Dice!");
        Messages.Add("------INVENTORY-------");
        Messages.Add($"{nunchucks.ItemName}"); 
        Messages.Add($"{katana.ItemName}"); 
        Messages.Add("press any key to return");

        }  

        public void Look()
        {
            //FIXME Messages.add(CurrentRoom.Description) see line 28//DONE
            Messages.Add($"{_game.CurrentRoom.Description}");

            //FIXME itterate over CurrentRoom.Items and print each item//DONE
            foreach (Item i in _game.CurrentRoom.Items)
            {
                Messages.Add($"{i.ItemName}");
            }
        }
        ///<summary>
        ///Restarts the game 
        ///</summary>
        public void Reset()
        {
            //NOTE re instantiate the game
            throw new System.NotImplementedException();
        }

        public void Setup(string playerName)
        {
            throw new System.NotImplementedException();
        }
        ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
        public void TakeItem(string itemName)
        {
            //FIXME Does the item exist in CurrentRoom 
                //var item = CurrentRoom.Find(i => i.Name.ToUpper() == itemName)
                //If item == null => add message for error and return
                //Else add to CurrentPlayer.Inventory
                    //Remove from room (CurrentRoom.Items.Remove(item))
            var item = _game.CurrentRoom.Items.Find(i=> i.ItemName.ToUpper() == itemName);
            if (item == null)
            {
                Messages.Add($"This item does not exist");
            }
            else
            {
               _game.CurrentPlayer.Inventory.Add(item);
             Messages.Add($"You now have {itemName}");
               _game.CurrentRoom.Items.Remove(item); 
            }

        }
        ///<summary>
        ///No need to Pass a room since Items can only be used in the CurrentRoom
        ///Make sure you validate the item is in the room or player inventory before
        ///being able to use the item
        ///</summary>
        public void UseItem(string itemName)
        {
            //FIXME Similar to take item, item will need to be found in the Player Inventory
            //Conditional on CurrentRoom.Name && item.Name
            // var item = _game.CurrentRoom.Items.Find(i=> i.ItemName.ToUpper() == itemName);
            var item = _game.CurrentPlayer.Inventory.Find(i => i.ItemName.ToUpper() == itemName);
            if (item == null)
            {
                Messages.Add($"You don't have this item in your possession!");
            }
            else if (_game.CurrentRoom.Name.ToLower() == "boss" && item.ItemName.ToLower() == "katana")
            {
                //WIN
                Messages.Add($"You are the master!");
                GameOver = true;
            }else{
                //LOSE
                Messages.Add($"Ouch!  Boss Wins...");
                GameOver = true;
            }
        }
    }
}