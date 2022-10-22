using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return base.Count == 0;
        }

        public Stack<string> AddRange()
        {
            return new Stack<string>();
        }
    }
}
