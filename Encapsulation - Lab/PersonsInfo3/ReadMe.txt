3.	Validation of Data
NOTE: You need a public StartUp class with the namespace PersonsInfo.
Expand Person with proper validation for every field:
•	Name must be at least 3 symbols
•	Age must not be zero or negative
•	Salary can't be less than 460 (decimal)
If some of the properties are NOT valid throw ArgumentExeption with the following messages:
•	"Age cannot be zero or a negative integer!"
•	"First name cannot contain fewer than 3 symbols!"
•	"Last name cannot contain fewer than 3 symbols!"
•	"Salary cannot be less than 650 leva!"
Examples
Input					Output
5
Andrew Williams -6 2200
B Gomez 57 3333
Carolina Richards 27 670
Gilbert H 44 666.66
Joshua Anderson 35 300
20	
				Age cannot be zero or a negative integer!
				First name cannot contain fewer than 3 symbols!
				Last name cannot contain fewer than 3 symbols!
				Salary cannot be less than 650 leva!
				Carolina Richards receives 737.00 leva.
