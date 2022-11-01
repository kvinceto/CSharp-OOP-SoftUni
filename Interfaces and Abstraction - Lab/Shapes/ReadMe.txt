1.	Shapes
NOTE: You need a public StartUp class with the namespace Shapes.
Build a hierarchy of interfaces and classes: 
 
You should be able to use the class like this:
StartUp.cs
var radius = int.Parse(Console.ReadLine());
IDrawable circle = new Circle(radius);

var width = int.Parse(Console.ReadLine());
var height = int.Parse(Console.ReadLine());
IDrawable rect = new Rectangle(width, height);

circle.Draw();
rect.Draw();

Examples

Input
			
3
4
5

Output

   *******
 **       **
**         **
*           *
**         **
 **       **
   *******
****
*  *
*  *
*  *
****
