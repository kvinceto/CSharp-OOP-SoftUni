7.	*Military Elite
Create the following class hierarchy:

•Soldier - general class for Soldiers, holding id, first name, and last name.
	o	Private - lowest base Soldier type, holding the salary(decimal). 
			LieutenantGeneral - holds a set of Privates under his command.
			SpecialisedSoldier - general class for all specialized Soldiers - holds the corps of the Soldier. 
			The corps can only be one of the following: Airforces or Marines.
			-	Engineer - holds a set of Repairs. A Repair holds a part name and hours worked(int).
			-	Commando - holds a set of Missions. A mission holds a code name and a state (inProgress or Finished). A Mission can be finished through the method CompleteMission().
	o	Spy - holds the code number of the Spy (int).

Extract interfaces for each class. (e.g. ISoldier, IPrivate, ILieutenantGeneral, etc.) 
The interfaces should hold their public properties and methods (e.g. ISoldier should hold id, first name, and last name). 
Each class should implement its respective interface. Validate the input where necessary (corps, mission state) - 
input should match exactly one of the required values, otherwise, it should be treated as invalid. 
In case of invalid corps, the entire line should be skipped, in case of an invalid mission state, only the mission should be skipped. 

You will receive from the console an unknown amount of lines containing information about soldiers until 
the command "End" is received. The information will be in one of the following formats:

•	Private: "Private <id> <firstName> <lastName> <salary>"

•	LeutenantGeneral: "LieutenantGeneral <id> <firstName> <lastName> <salary> <private1Id> <private2Id> … <privateNId>" 
where privateXId will always be an Id of a Private already received through the input.

•	Engineer: "Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>" 
where repairXPart is the name of a repaired part and repairXHours the hours it took to repair it (the two parameters will always come paired).
 
•	Commando: "Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>"
a missions code name, description and state will always come together.

•	Spy: "Spy <id> <firstName> <lastName> <codeNumber>"

Define proper constructors. 
Avoid code duplication through abstraction. 
Override ToString() in all classes to print detailed information about the object.
•	Privates:
Name: <firstName> <lastName> Id: <id> Salary: <salary>

•	Spy:
Name: <firstName> <lastName> Id: <id>
Code Number: <codeNumber>

•	LieutenantGeneral:
Name: <firstName> <lastName> Id: <id> Salary: <salary>
Privates:
  <private1 ToString()>
  <private2 ToString()>
  …
  <privateN ToString()>

•	Engineer:
Name: <firstName> <lastName> Id: <id> Salary: <salary>
Corps: <corps>
Repairs:
  <repair1 ToString()>
  <repair2 ToString()>
  …
  <repairN ToString()>

•	Commando:
Name: <firstName> <lastName> Id: <id> Salary: <salary>
Corps: <corps>
Missions:
  <mission1 ToString()>
  <mission2 ToString()>
  …
  <missionN ToString()>

•	Repair:
Part Name: <partName> Hours Worked: <hoursWorked>

•	Mission:
Code Name: <codeName> State: <state>
NOTE: Salary should be printed rounded to two decimal places after the separator.

Examples
Input	

Private 1 Peter Johnson 22.22
Commando 13 Sam Peterson 13.1 Airforces
Private 222 Tony Samthon 80.08
LieutenantGeneral 3 George Stevenson 100 222 1
End	

Output

Name: Peter Johnson Id: 1 Salary: 22.22
Name: Sam Peterson Id: 13 Salary: 13.10
Corps: Airforces
Missions:
Name: Tony Samthon Id: 222 Salary: 80.08
Name: George Stevenson Id: 3 Salary: 100.00
Privates:
  Name: Tony Samthon Id: 222 Salary: 80.08
  Name: Peter Johnson Id: 1 Salary: 22.22
