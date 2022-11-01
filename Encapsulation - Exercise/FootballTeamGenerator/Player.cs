namespace FootballTeamGenerator
{
    using System;

    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            stats = new Stats(endurance, sprint, dribble, passing, shooting);
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

        public double AverageSkillLevel =>
            (stats.Endurance + stats.Dribble + stats.Shooting + stats.Passing + stats.Sprint) / 5.0;
    }
}
