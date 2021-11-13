using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AutoPark.Garage
{
    public class MyStack<T> : IEnumerable<T>
    {
        private const int DefaultSize = 10;
        private int _firstIndex;
        private int _lastIndex;
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

        public int Count { get; private set; }

        public void Push(T item)
        {
            if(Count == _stack.Length)
            {
                SetCapacity(_stack.Length * 2);
            }
            if(Count == 0)
            {
                _stack[_lastIndex] = item;
            }
            else
            {
                _stack[++_lastIndex] = item;
            }
            Count++;
        }

        public T Pop()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
            var popItem = _stack[_lastIndex];
            _lastIndex--;
            Count--;
            return popItem;
        }

        public void Clear()
        {
            Array.Clear(_stack, 0, _stack.Length);
        }


        public IEnumerator<T> GetEnumerator()
        {
            var i = _lastIndex;
            while(i >= _firstIndex)
            {
                yield return _stack[i++];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void SetCapacity(int capacity)
        {
            if (_stack == null)
            {
                throw new ArgumentNullException();
            }

            var newStack = new T[capacity];

            Array.Copy(_stack, newStack, _stack.Length);
            _stack = newStack;
        }
    }
}
