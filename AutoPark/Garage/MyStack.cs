using System;
using System.Collections;
using System.Collections.Generic;

namespace AutoPark.Garage
{
    public class MyStack<T> : IEnumerable<T>
    {
        private const int DefaultSize = 10;
        private int _headIndex;
        private T[] _stack;

        public MyStack()
        {
            _stack = new T[DefaultSize];
        }

        public MyStack(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }
            _stack = new T[DefaultSize];
            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public MyStack(int size)
        {
            if(size <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _stack = new T[size];
        }

        public int Count => _headIndex;

        public void Push(T item)
        {
            if(Count == _stack.Length)
            {
                var newStack = new T[_stack.Length + DefaultSize];
                Array.Copy(_stack, newStack, _stack.Length);
                _stack = newStack;
            }
            _stack[_headIndex++] = item;
        }

        public T Pop()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
            var popItem = _stack[_headIndex - 1];
            var newStack = new T[_stack.Length - 1];
            Array.Copy(_stack, newStack, --_headIndex);
            _stack = newStack;
            return popItem;
        }

        public void Clear()
        {
            Array.Clear(_stack, 0, _stack.Length);
            _headIndex = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _headIndex; i++)
            {
                yield return _stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
