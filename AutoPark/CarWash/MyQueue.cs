using System;
using System.Collections;
using System.Collections.Generic;

namespace AutoPark.CarWash
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private const int DefaultSize = 10;
        private int _firstIndex;
        private int _lastIndex;
        private T[] _queue;

        public MyQueue()
        {
            _queue = new T[DefaultSize];
        }

        public MyQueue(int size)
        {
            if(size <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _queue = new T[size];
        }

        public MyQueue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }
            _queue = new T[DefaultSize];
            foreach(var item in collection)
            {
                Enqueue(item);
            }

        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if(Count == _queue.Length)
            {
                SetCapacity(_queue.Length * 2);
            }
            if(Count == 0)
            {
                _queue[_lastIndex] = item;
            }
            else
            {
                _queue[++_lastIndex] = item;
            }
            Count++;
        }

        public T Dequeue()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
            var dequeueItem = _queue[_firstIndex];
            _firstIndex++;
            Count--;
            return dequeueItem;
        }

        public void Clear()
        {
            Array.Clear(_queue, 0, _queue.Length);
        }

        public bool Contains(T item)
        {
            for(int i = _firstIndex; i <= _lastIndex; i++)
            {
                if (_queue[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var i = _firstIndex;

            while(i <= _lastIndex)
            {
                yield return _queue[i++];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void SetCapacity(int capacity)
        {
            if (_queue == null)
            {
                throw new ArgumentNullException();
            }

            var newQueue = new T[capacity];

            Array.Copy(_queue, newQueue, _queue.Length);
            _queue = newQueue;
        }
    }
}
