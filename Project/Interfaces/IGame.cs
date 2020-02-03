using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Interfaces
{
    public interface IGame
    {
        IRoom CurrentRoom { get; set; }
        IPlayer CurrentPlayer { get; set; }
        IItem CurrentItem { get; set; }

        void Setup();
    }
}