using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private string name;
        private int playerNumber;
        private string position;
        private FootballPlayer player;

        private string teamName;
        private int capacity;
        private FootballTeam team;


        [SetUp]
        public void Setup()
        {
            name = "Ivan";
            playerNumber = 9;
            position = "Goalkeeper";
            player = new FootballPlayer(name, playerNumber, position);
            teamName = "Arsenal";
            capacity = 20;
            team = new FootballTeam(teamName, capacity);
        }

        [Test]
        public void PlayerConstructorWorks()
        {
            Assert.IsNotNull(player);
            Assert.AreEqual(name, player.Name);
            Assert.AreEqual(playerNumber, player.PlayerNumber);
            Assert.AreEqual(position, player.Position);
            Assert.AreEqual(0, player.ScoredGoals);
        }

        [TestCase(null, 2, "Midfielder")]
        [TestCase("", 2, "Midfielder")]
        [TestCase("Ivan", 0, "Midfielder")]
        [TestCase("Ivan", 22, "Midfielder")]
        [TestCase("Ivan", 2, "Pazach")]
        public void PlayerSettersThrows(string pName, int number, string pos)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                player = new FootballPlayer(pName, number, pos);
            });
        }

        [Test]
        public void PlayerScoreWorks()
        {
            player.Score();
            Assert.AreEqual(1, player.ScoredGoals);
        }

        [Test]
        public void TeamConstructor()
        {
            Assert.IsNotNull(team);
            Assert.AreEqual(teamName, team.Name);
            Assert.AreEqual(capacity, team.Capacity);
            Assert.IsNotNull(team.Players);
            Assert.AreEqual(0, team.Players.Count);
            Assert.True(team.Players is List<FootballPlayer>);
        }

        [TestCase(null, 20)]
        [TestCase("", 20)]
        [TestCase("A-team", 10)]
        [TestCase("A-team", 14)]
        public void TeamSettersThrows(string newTeamName, int newTeamCap)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(newTeamName, newTeamCap);
            });
        }

        [Test]
        public void TeamAddNewPlayerWorks()
        {
            string result = team.AddNewPlayer(player);
            string expected =
                $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";
            Assert.AreEqual(expected, result);

        }

        [Test]
        public void TeamAddNewPlayerThrows()
        {
            team = new FootballTeam(teamName, 15);
            for (int i = 1; i <= 15; i++)
            {
                string s = team.AddNewPlayer(player);
            }
            
            string expected = "No more positions available!";
            string result = team.AddNewPlayer(player);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TeamPickPlayerWorks()
        {
            string s = team.AddNewPlayer(player);

           var p = team.PickPlayer(name);

           Assert.AreEqual(player, p);
        }

        [Test]
        public void TeamPickPlayerNull()
        {
            string s = team.AddNewPlayer(player);
            var p = team.PickPlayer("Georgi");
            
            Assert.IsNull(p);
        }

        [Test]
        public void TeamPlayerScoreWorks()
        {
            string s = team.AddNewPlayer(player);
            string result = team.PlayerScore(playerNumber);
            string expected = $"{player.Name} scored and now has {player.ScoredGoals} for this season!";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TeamPlayerScoreThrows()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                team.PlayerScore(playerNumber);
            });
        }

        [Test]
        public void TeamPlayerScoreWorks2()
        {
            string s = team.AddNewPlayer(player);
            string result = team.PlayerScore(playerNumber);
            string expected = $"{player.Name} scored and now has {player.ScoredGoals} for this season!";
            Assert.AreEqual(1, player.ScoredGoals);
        }
    }
}