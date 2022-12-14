Problem 2.	Extended Database
You already have a class - Database. 
We have modified it and added some more functionality to it. 
It supports adding, removing, and finding People. 
In other words, it stores People. 
There are two types of finding methods - first: "FindById (long id)" 
and the second one: "FindByUsername (string username)". 
As you may guess, each person has unique id and unique username. Your task is to test the provided project.

Constraints
The database should have methods:
•	Add
o	If there are already users with this username, InvalidOperationException is thrown
o	If there are already users with this id, InvalidOperationException is thrown
•	Remove
•	FindByUsername
o	If no user is present by this username, InvalidOperationException is thrown.
o	If the username parameter is null, ArgumentNullException is thrown
o	Arguments are all CaseSensitive
•	FindById
o	If no user is present by this id, InvalidOperationException is thrown
o	If negative ids are found, ArgumentOutOfRangeException is thrown
