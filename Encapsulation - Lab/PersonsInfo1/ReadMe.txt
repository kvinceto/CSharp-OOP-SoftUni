1.	Sort Persons by Name and Age
NOTE: You need a public StartUp class with the namespace PersonsInfo.
Create a class Person, which should have public properties with private setters for:
•	FirstName: string
•	LastName: string
•	Age: int
•	ToString(): string - override
You should be able to use the class like this:
StartUp.cs
public static void Main()
{
    var lines = int.Parse(Console.ReadLine());
    var persons = new List<Person>();
    for (int i = 0; i < lines; i++)
    {
        var cmdArgs = Console.ReadLine().Split();
        var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
        persons.Add(person);
    }

    persons.OrderBy(p => p.FirstName)
           .ThenBy(p => p.Age)
           .ToList()
           .ForEach(p => Console.WriteLine(p.ToString()));
}
Examples
Input					Output
5
Brandi Anderson 65
Andrew Williams 57
Newton Holland 27
Andrew Clark 44
Brandi Scott 35	
					Andrew Clark is 44 years old.
					Andrew Williams is 57 years old.
					Brandi Scott is 35 years old.
					Brandi Anderson is 65 years old.
					Newton Holland is 27 years old.
