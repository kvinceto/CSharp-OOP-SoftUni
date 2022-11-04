using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stablephone = new StationaryPhone();

            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();
            foreach (var phoneNumber in phoneNumbers)
            {
                bool valid = true;
                foreach (var n in phoneNumber)
                {
                    if (!Char.IsDigit(n))
                    {
                        valid = false;
                        break;
                    }
                }

                if (!valid)
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (phoneNumber.Length == 10)
                {
                    smartphone.PhoneNumber = phoneNumber;
                    smartphone.Call();
                }
                else if (phoneNumber.Length == 7)
                {
                    stablephone.PhoneNumber = phoneNumber;
                    stablephone.Call();
                }
            }

            foreach (var url in urls)
            {
                bool valid = true;
                foreach (var t in url)
                {
                    if (Char.IsDigit(t))
                    {
                        valid = false;
                        break;
                    }
                }

                if (!valid)
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartphone.URL = url;
                    smartphone.Browsing();
                }
            }
        }
    }
}
