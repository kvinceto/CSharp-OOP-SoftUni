using System;

namespace Telephony
{
    public class StationaryPhone : IPhonable
    {
        public string PhoneNumber { get; set; }

        public void Call()
        {
            Console.WriteLine($"Dialing... {PhoneNumber}");
        }
    }
}
