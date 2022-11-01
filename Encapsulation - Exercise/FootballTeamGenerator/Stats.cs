namespace FootballTeamGenerator
{
    using System;

    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get => endurance;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(Exceptions.IncorrectValue, nameof(Endurance)));
                }
                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(Exceptions.IncorrectValue, nameof(Sprint)));
                }
                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new AggregateException(string.Format(Exceptions.IncorrectValue, nameof(Dribble)));
                }
                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(Exceptions.IncorrectValue, nameof(Passing)));
                }
                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(Exceptions.IncorrectValue, nameof(Shooting)));
                }
                shooting = value;
            }
        }
    }
}
