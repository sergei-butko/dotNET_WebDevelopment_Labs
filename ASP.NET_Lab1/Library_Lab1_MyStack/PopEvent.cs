using System;

namespace Library_Lab1_MyStack
{
    public class PopEvent : StackEventArgs
    {
        public PopEvent(string element, Type type) : base(element, type)
        {
            Element = element;
            EventType = typeof(StackEventArgs);
        }
        private string Element { get; }
        private Type EventType { get; }
    }
}