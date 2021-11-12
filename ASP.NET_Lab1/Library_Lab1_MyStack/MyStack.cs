using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Library_Lab1_MyStack
{
    public sealed class MyStack<T> : IEnumerable<T>
    {
        public event EventHandler<StackEventArgs> StackEvent;

        private StackNode<T> _head;

        public int Size { get; private set; }
        public bool IsEmpty => Size == 0;

        // Adding new elements method
        public void Push(T elem)
        {
            var newNode = new StackNode<T>(elem) {Next = _head};
            _head = newNode;
            Size++;

            var args = new StackEventArgs(_head.Value.ToString());
            StackEventMethod(args);
        }

        // Last element removal method
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            var temp = _head;
            _head = _head.Next;
            Size--;

            var args = new StackEventArgs(temp.Value.ToString());
            StackEventMethod(args);

            return temp.Value;
        }

        // Last element showing method
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            var args = new StackEventArgs(_head.Value.ToString());
            StackEventMethod(args);

            return _head.Value;
        }

        private void StackEventMethod(StackEventArgs e)
        {
            var temp = Volatile.Read(ref StackEvent);
            temp?.Invoke(this, e);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            StackNode<T> current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
}