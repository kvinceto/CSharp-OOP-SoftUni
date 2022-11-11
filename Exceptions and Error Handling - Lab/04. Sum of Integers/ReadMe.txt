4.	Sum of Integers

You will receive a sequence of elements of different types, separated by space. 
Your task is to calculate the sum of all valid integer numbers in the input. 
Try to add each element of the array to the sum and write messages for the possible exceptions while processing the element:

•	If you receive an element, which is not in the correct format (FormatException):
"The element '{element}' is in wrong format!"

•	If you receive an element, which is out of the integer type range (OverflowException):
"The element '{element}' is out of range!"

After each processed element add the following message:
	"Element '{element}' processed - current sum: {sum}"

At the end print the total sum of all integers:
	"The total sum of all integers is: {sum}"

Examples
Input	

2147483649 2 3.4 5 invalid 24 -4	

Output

The element '2147483649' is out of range!
Element '2147483649' processed - current sum: 0
Element '2' processed - current sum: 2
The element '3.4' is in wrong format!
Element '3.4' processed - current sum: 2
Element '5' processed - current sum: 7
The element 'invalid' is in wrong format!
Element 'invalid' processed - current sum: 7
Element '24' processed - current sum: 31
Element '-4' processed - current sum: 27
The total sum of all integers is: 27
