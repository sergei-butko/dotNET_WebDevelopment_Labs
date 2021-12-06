using System;

namespace Library_Lab1_MyStack
{
    public class PushEvent : StackEventArgs
    {
        public PushEvent(string element, Type type) : base(element, type)
        {
            Element = element;
            EventType = type;
        }
        private string Element { get; }
        private Type EventType { get; }
    }
}