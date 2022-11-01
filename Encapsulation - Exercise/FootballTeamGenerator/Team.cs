namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players;

        public Team()
        {
            players = new List<Player>();
        }

        public Team(string name) : this()
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(Exceptions.NameCanNotBeEmpty));
                }
                name = value;
            }
        }

        public int Rating
        {
            get
            {
                return players.Count > 0
                     ? (int)Math.Round(players.Average(p => p.AverageSkillLevel), 0)
                     : 0;
            }
        }

        public void AddPlayer(Player player) => players.Add(player);

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);
            if (player == null) 
                throw  new ArgumentException(string.Format(Exceptions.PlayerNotPresent, playerName, Name));
            players.Remove(player);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
