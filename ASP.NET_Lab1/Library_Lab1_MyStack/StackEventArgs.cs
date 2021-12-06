using System;

namespace Library_Lab1_MyStack
{
    public abstract class StackEventArgs : EventArgs
    {
        protected StackEventArgs(string args, Type type)
        {
            Event = args;
            EventType = type;
        }

        private string Event { get; }
        private Type EventType { get; }
    }
}