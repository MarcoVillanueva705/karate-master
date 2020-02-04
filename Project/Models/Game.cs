using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
    public class Game : IGame
    {
        public IRoom CurrentRoom { get; set; }
        public IPlayer CurrentPlayer { get; set; }
        public IItem CurrentItem { get; set; }

        //NOTE Make yo rooms here...
        public void Setup()
        {
            Room Monkey = new Room("Monkey", "You are now in the Chamber that starts your quest.");
            Room Pit = new Room("Pit", "You have chosen poorly and have fallen into a pit!");
            Room Crane = new Room("Crane", "In this Chamber you will find a weapon to master.");
            Room Boss = new Room("Boss", "Face the boss in order to become the master!");
            Room Top = new Room("Top", "You are the Master!");

            //FIXME Instatiate a new Player();
            Player Ninja = new Player("Dragon");//DONE

        //Create Room Relationships
        Monkey.AddExit(Pit);
        Monkey.AddExit(Crane);
        Crane.AddExit(Boss);
        Boss.AddExit(Top);

        //Add items to rooms
        Crane.Items.Add(new Item("Nunchucks", "Use these to defeat the Boss!" ));
        Crane.Items.Add(new Item("Katana", "Slice and dice!"));
        Boss.Items.Add(new Item("Nunchucks", "Use these to defeat the Boss!" ));
        Boss.Items.Add(new Item("Katana", "Slice and dice!"));

        CurrentRoom = Monkey;
        CurrentPlayer = Ninja;

        
        }

        public Game()
        {
            Setup();
        }
        
    }
}