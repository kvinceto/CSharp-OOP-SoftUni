6.	Money Transactions

You will receive on the first line a collection of bank accounts, 
consisting of an account number (integer) and its balance (double), in the following format:

"{account number}-{account balance},{account number}-{account balance},…"

 After that, until the "End" command, you will receive commands, which should manipulate the given account`s balance:

•	"Deposit {account number} {sum}" – Add the given sum to the given account`s balance.
 
•	"Withdraw {account number} {sum}" – Subtract the given sum from the account`s balance.

Print the following messages from the exceptions which can be produced from your program:

•	If you receive an invalid command:
"Invalid command!"

•	If you receive an account, which does not exist:
"Invalid account!"

•	If you receive the "Withdraw" command with the sum, which is bigger than the balance:
"Insufficient balance!"

In all cases, after each received command, print the message:
	"Enter another command"

After each successful operation print, the new balance is formatted to the second integer after the decimal point:
	"Account {account number} has new balance: {balance}"

Examples

Input	

1-45.67,2-3256.09,3-97.34
Deposit 1 50
Withdraw 3 100
End	

Output

Account 1 has new balance: 95.67
Enter another command
Insufficient balance!
Enter another command
