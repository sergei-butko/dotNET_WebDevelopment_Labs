using System;

namespace Library_Lab1_MyStack
{
    public class StackEventArgs : EventArgs
    {
        public StackEventArgs(string args)
        {
            Event = args;
        }

        public string Event { get; }
    }
}