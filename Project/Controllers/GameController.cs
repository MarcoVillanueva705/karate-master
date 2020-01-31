using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

    public class GameController : IGameController
    {
        private GameService _gameService = new GameService();
        private bool _walking = true;

        //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
        public void Run()
        {
            _gameService.StartGame();
            while (_walking)
            {
               PrintMessages();
               GetUserInput(); 
            }
            Console.Clear();
            System.Console.WriteLine("Bow to your Sensei...");
        }

        //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
        public void GetUserInput()
        {
            Console.WriteLine("What would you like to do?");
            string input = Console.ReadLine().ToLower() + " ";
            string command = input.Substring(0, input.IndexOf(" "));
            string option = input.Substring(input.IndexOf(" ") + 1).Trim();
            //NOTE this will take the user input and parse it into a command and option.
            //IE: take silver key => command = "take" option = "silver key"
            Console.Clear();
            switch(input)
            {
            case "Q":
            case "QUIT":
            case "EXIT":
            _walking = false;
            break;
            case "HELP":
            _gameService.Help();            
            PrintMessages();
            Console.ReadKey();
            Console.Clear();
            _gameService.StartGame();
            break;
            case "INVENTORY":
            _gameService.Inventory();            
            PrintMessages();
            Console.ReadKey();
            Console.Clear();
            _gameService.StartGame();
            break;
            case "LOOK":
            _gameService.Look();            
            PrintMessages();
            Console.ReadKey();
            Console.Clear();
            _gameService.StartGame();
            break;
             case "START":
            _gameService.Setup("");            
            PrintMessages();
            Console.ReadKey();
            Console.Clear();
            _gameService.StartGame();
            break;
            case "GRAB":
            _gameService.TakeItem("");            
            PrintMessages();
            Console.ReadKey();
            Console.Clear();
            _gameService.StartGame();
            break;
            case "FIGHT":
            _gameService.UseItem("");            
            PrintMessages();
            Console.ReadKey();
            Console.Clear();
            _gameService.StartGame();
            break;
            default:
            _gameService.Go(input);
            _gameService.StartGame();
            break;
            }

        }

        //NOTE this should print your messages for the game.
        private void PrintMessages()
        {
            foreach (string message in _gameService.Messages)
            {
                System.Console.WriteLine(message);
            }
            _gameService.Messages.Clear();
        }

    }
}