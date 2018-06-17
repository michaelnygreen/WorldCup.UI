using System;

namespace WorldCup.UI.Models
{
    public class Team
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Group { get; set; }

        public Player[] Players { get; set; }
    }
}
