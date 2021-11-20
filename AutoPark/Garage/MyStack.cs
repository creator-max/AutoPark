using System;
using System.Collections;
using System.Collections.Generic;

namespace AutoPark.Garage
{
    public class MyStack<T> : IEnumerable<T>
    {
        private const int DefaultSize = 10;
        private T[] _stack;

        public MyStack()
        {
            _stack = new T[DefaultSize];
        }

        public MyStack(IEnumerable<T> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection), "Collection can't be empty.");
            
            _stack = new T[DefaultSize];
            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public MyStack(int size)
        {
            if(size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size), "Stack size can't be <= 0.");
            
            _stack = new T[size];
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if(Count == _stack.Length)
            {
                var newStack = new T[_stack.Length + DefaultSize];
                Array.Copy(_stack, newStack, _stack.Length);
                _stack = newStack;
            }
            _stack[Count++] = item;
        }

        public T Pop()
        {
            if(Count == 0)
                throw new InvalidOperationException("Can't apply operation Pop() to stack with 0 elements.");

            return _stack[--Count];
        }

        public void Clear()
        {
            Array.Clear(_stack, 0, _stack.Length);
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
