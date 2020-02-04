using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, IRoom> Exits { get; set; }
    //Method for adding rooms
    public void AddExit(IRoom ex)
    {
        Exits.Add(ex.Name, ex);
        ex.Exits.Add(Name, this);
    }

    public Room(string name, string description)
    {
        Name = name.ToUpper();
        Description = description;
        Exits = new Dictionary<string, IRoom>();
        Items = new List<Item>();
    }

    }

}