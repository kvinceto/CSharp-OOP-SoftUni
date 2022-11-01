using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{

    public class StartUp
    {
        private static List<Team> teams;

        static void Main(string[] args)
        {
            teams = new List<Team>();
            while (true)
            {
                try
                {
                    string[] command = Console.ReadLine().Split(';');
                    if (command[0] == "END")
                    {
                        break;
                    }
                    else if (command[0] == "Team")
                    {
                        string teamName = command[1];
                        CreateTeam(teamName);
                    }
                    else if (command[0] == "Add")
                    {
                        AddPlayer(command);
                    }
                    else if (command[0] == "Remove")
                    {
                        RemovePlayer(command);
                    }
                    else if (command[0] == "Rating")
                    {
                        string teamName = command[1];
                        Rating(teamName);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void Rating(string teamName)
        {
            Team teamToPrint = teams.FirstOrDefault(t => t.Name == teamName);
            if (teamToPrint == null)
            {
                throw new ArgumentException(string.Format(Exceptions.TeamNameInvalid, teamName));
            }

            Console.WriteLine(teamToPrint.ToString());
        }

        private static void RemovePlayer(string[] command)
        {
            string teamName = command[1];
            string playerName = command[2];
            Team teamToRemoveFrom = teams.FirstOrDefault(t => t.Name == teamName);
            if (teamToRemoveFrom == null)
            {
                throw new ArgumentException(string.Format(Exceptions.TeamNameInvalid, teamName));
            }
            teamToRemoveFrom.RemovePlayer(playerName);

        }

        private static void AddPlayer(string[] command)
        {
            string teamName = command[1];
            string playerName = command[2];
            int endurance = int.Parse(command[3]);
            int sprint = int.Parse(command[4]);
            int dribble = int.Parse(command[5]);
            int passing = int.Parse(command[6]);
            int shooting = int.Parse(command[7]);
            Team teamToAddTo = teams.FirstOrDefault(t => t.Name == teamName);
            if (teamToAddTo == null)
            {
                throw new ArgumentException(string.Format(Exceptions.TeamNameInvalid, teamName));
            }

            Player playerToAdd = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            teamToAddTo.AddPlayer(playerToAdd);
        }

        public static void CreateTeam(string teamName)
        {
            Team team = new Team(teamName);
            teams.Add(team);
        }
    }
}
