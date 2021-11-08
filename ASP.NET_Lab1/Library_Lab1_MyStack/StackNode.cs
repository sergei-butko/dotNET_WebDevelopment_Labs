using System;

namespace Library_Lab1_MyStack
{
    public class StackNode<T>
    {
        public StackNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            Value = value;
        }

        public T Value { get; }
        public StackNode<T> Next { get; init; }
    }
}