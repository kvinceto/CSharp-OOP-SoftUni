using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _06._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            string[] accountsInfo = Console.ReadLine().Split(',');
            foreach (var account in accountsInfo)
            {
                string[] data = account.Split('-');
                accounts.Add(int.Parse(data[0]), double.Parse(data[1]));
            }

            while (true)
            {
                string[] cmd = Console.ReadLine().Split(' ');
                if(cmd[0] == "End") break;

                try
                {
                    switch (cmd[0])
                    {
                        case "Deposit":
                            DepositToAcc(cmd, accounts);
                            break;
                        case "Withdraw":
                            WithdrawFromAcc(cmd, accounts);
                            break;
                        default:
                            throw new ArgumentException();
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Invalid command!");
                }
                catch (IndexOutOfRangeException iofre)
                {
                    Console.WriteLine(iofre.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }   
        }

        private static void DepositToAcc(string[] cmd, Dictionary<int, double> accounts)
        {
            int accNumber = int.Parse(cmd[1]);
            double balance = double.Parse(cmd[2]);
            if (!accounts.ContainsKey(accNumber))
                throw new IndexOutOfRangeException("Invalid account!");
            accounts[accNumber] += balance;
            Message(accNumber, accounts[accNumber]);
        }

        private static void WithdrawFromAcc(string[] cmd, Dictionary<int, double> accounts)
        {
            int accNumber = int.Parse(cmd[1]);
            double balance = double.Parse(cmd[2]);
            if (!accounts.ContainsKey(accNumber))
                throw new IndexOutOfRangeException("Invalid account!");
            if (accounts[accNumber] < balance)
                throw new IndexOutOfRangeException("Insufficient balance!");
            accounts[accNumber] -= balance;
            Message(accNumber, accounts[accNumber]);
        }

        private static void Message(int accNumber, double bal)
        {
            Console.WriteLine($"Account {accNumber} has new balance: {bal:f2}");
        }
    }
}
