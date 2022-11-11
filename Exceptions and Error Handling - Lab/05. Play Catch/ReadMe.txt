5.	Play Catch

You will receive on the first line an array of integers. 
After that you will receive commands, which should manipulate the array:

•	"Replace {index} {element}" – Replace the element at the given index with the given element. 

•	"Print {startIndex} {endIndex}" – Print the elements from the start index to the end index inclusive.

•	"Show {index}" – Print the element at the index.

You have the task to rewrite the messages from the exceptions which can be produced from your program:

•	If you receive an index, which does not exist in the array print:
"The index does not exist!"

•	If you receive a variable, which is of invalid type:
"The variable is not in the correct format!"

 When you catch 3 exceptions – stop the input and print the elements of the array separated with ", ".

Examples

Input	

1 2 3 4 5
Replace 1 9
Replace 6 3
Show 3
Show peter
Show 6	

Output

The index does not exist!
4
The variable is not in the correct format!
The index does not exist!
1, 9, 3, 4, 5
