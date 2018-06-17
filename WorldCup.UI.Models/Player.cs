using System;

namespace WorldCup.UI.Models
{
    public class Player
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Club { get; set; }

        public Position Position { get; set; }
        public int SquadNumber { get; set; }

        public int Caps { get; set; }
        public int Goals { get; set; }

        public int Height { get; set; }
        public int Weigth { get; set; }
    }
}
