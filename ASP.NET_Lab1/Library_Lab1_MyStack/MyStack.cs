using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Library_Lab1_MyStack
{
    public sealed class MyStack<T> : IEnumerable<T>
    {
        public event EventHandler<PushEvent> StackPushEvent;
        public event EventHandler<PopEvent> StackPopEvent;
        public event EventHandler<PeekEvent> StackPeekEvent;

        private StackNode<T> _head;

        public int Size { get; private set; }
        public bool IsEmpty => Size == 0;

        // Adding new elements method
        public void Push(T elem)
        {
            var newNode = new StackNode<T>(elem) {Next = _head};
            _head = newNode;
            Size++;

            var args = new PushEvent(_head.Value.ToString(), typeof(PushEvent));
            OnStackPushEvent(args);
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

            var args = new PopEvent(temp.Value.ToString(), typeof(PopEvent));
            OnStackPopEvent(args);

            return temp.Value;
        }

        // Last element showing method
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            var args = new PeekEvent(_head.Value.ToString(), typeof(PeekEvent));
            OnStackPeekEvent(args);

            return _head.Value;
        }

        private void OnStackPushEvent(PushEvent e)
        {
            var temp = Volatile.Read(ref StackPushEvent);
            temp?.Invoke(this, e);
        }

        private void OnStackPopEvent(PopEvent e)
        {
            var temp = Volatile.Read(ref StackPopEvent);
            temp?.Invoke(this, e);
        }
        
        private void OnStackPeekEvent(PeekEvent e)
        {
            var temp = Volatile.Read(ref StackPeekEvent);
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