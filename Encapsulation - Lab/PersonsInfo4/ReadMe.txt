4.	First and Reserve Team
NOTE: You need a public StartUp class with the namespace PersonsInfo. 
Create a Team class. 
Add to this team all of the people you have received. 
Those who are younger than 40 go to the first team, others go to the reserve 
At the end print the sizes of the first and the reserved team.

The class should have private fields for:
•	name: string
•	firstTeam: List<Person>
•	reserveTeam: List<Person>
The class should have constructors:
•	Team(string name)
The class should also have public properties for:
•	FirstTeam: List<Person> (read-only!)
•	ReserveTeam: List<Person> (read-only!)
And a method for adding players:
•	AddPlayer(Person person): void
You should be able to use the class like this:
StartUp.cs
Team team = new Team("SoftUni");

foreach (Person person in persons)
{
    team.AddPlayer(person);
}
You should NOT be able to use the class like this:
StartUp.cs
Team team = new Team("SoftUni");

foreach (Person person in persons)
{
    if(person.Age < 40)
    {
        team.FirstTeam.Add(person);
    }
    else
    {
        team.ReserveTeam(person);
    }
}
Examples
Input					Output
5
Andrew Williams 20 2200
Newton Holland 57 3333
Rachelle Nelson 27 600
Grigor Dimitrov 25 666.66
Brandi Scott 35 555	
					First team has 4 players.
					Reserve team has 1 players.

