2.	Cars
NOTE: You need a public StartUp class with the namespace Cars.
Build a hierarchy of interfaces and classes:
 
Your hierarchy must be used with this code:
StartUp.cs
ICar seat = new Seat("Leon", "Grey");
ICar tesla = new Tesla("Model 3", "Red", 2);

Console.WriteLine(seat.ToString());
Console.WriteLine(tesla.ToString());

Examples
Output
Grey Seat Leon
Red Tesla Model 3 with 2 Batteries

