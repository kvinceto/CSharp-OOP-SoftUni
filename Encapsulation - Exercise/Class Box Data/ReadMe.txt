1.	Class Box Data
Create a class Box, which has the following properties:
•	Length - double, should not be zero or negative number
•	Width - double, should not be zero or negative number
•	Height - double, should not be zero or negative number
If one of the properties is a zero or negative number throw ArgumentException with the message: 
"{propertyName} cannot be zero or negative."
Use try-catch block to process the error. 
All properties are set by the constructor and when set, they cannot be modified.

Behavior
double SurfaceArea()
Calculate and return the surface area of the Box.

double LateralSurfaceArea()
Calculate and return the lateral surface area of the Box.

double Volume()
Calculate and return the volume of the Box.

Input
•	On the first three lines, you will get the length, width, and height. 
Output
•	On the next three lines print the surface area, lateral surface area, and the volume of the box:
Examples
Input			Output
2
3
4	
			Surface Area - 52.00
			Lateral Surface Area - 40.00
			Volume - 24.00
