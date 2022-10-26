3.	Players and Monsters
NOTE: You need a public class StartUp.
Your task is to create the following game hierarchy: 
					     Hero

				  Elf	    Wizard	Knight
				MuseElf	   DarkWizard 	DarkKnight
					   SoulMaster	BladeKnight
 
Create a class Hero. It should contain the following members:
•	A constructor, which accepts:
o	username – string
o	level – int
•	The following properties:
o	Username - string
o	Level – int
•	ToString() method
Hint: Override ToString() of the base class in the following way:


public override string ToString()
{
    return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
}
