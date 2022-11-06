1.	MathOperation

Create a class MathOperations, which should have 3 times method Add(). 
Method Add() has to be invoked with:
•	Add(int, int): int
•	Add(double, double, double): double
•	Add(decimal, decimal, decimal): decimal

You should be able to use the class like this:

public static void Main()
{
   MathOperations mo = new MathOperations();
   Console.WriteLine(mo.Add(2, 3));
   Console.WriteLine(mo.Add(2.2, 3.3, 5.5));
   Console.WriteLine(mo.Add(2.2m, 3.3m, 4.4m));
}

Examples

Output

5
11
9.9
