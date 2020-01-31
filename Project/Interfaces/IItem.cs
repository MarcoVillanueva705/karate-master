using System.Collections.Generic;

namespace ConsoleAdventure.Project.Interfaces
{
    public interface IItem
    {
        string ItemName { get; set; }
        string ItemDescription { get; set; }
    }
}