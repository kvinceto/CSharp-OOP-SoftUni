using System;

namespace Telephony
{
    public class Smartphone : IPhonable, IBrowserable
    {
        public string PhoneNumber { get; set; }
        public string URL { get; set; }

        public void Call()
        {
            Console.WriteLine($"Calling... {PhoneNumber}");
        }

        public void Browsing()
        {
            Console.WriteLine($"Browsing: {URL}!");
        }
    }
}
