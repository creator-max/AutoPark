using System;
using System.Collections;
using System.Collections.Generic;

namespace AutoPark.CarWash
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private const int DefaultSize = 10;
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

        public int Count => _lastIndex;

        public void Enqueue(T item)
        {
            if(Count == _queue.Length)
            {
                var newSize = _queue.Length + DefaultSize;
                var newQueue = new T[newSize];
                Array.Copy(_queue, newQueue, _queue.Length);
                _queue = newQueue;
            }
            _queue[_lastIndex++] = item; 
        }

        public T Dequeue()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
            var dequeueItem = _queue[0];
            var newQueue = new T[_queue.Length - 1];
            Array.Copy(_queue, 1, newQueue, 0, --_lastIndex);
            _queue = newQueue;
            return dequeueItem;
        }

        public void Clear()
        {
            Array.Clear(_queue, 0, _queue.Length);
            _lastIndex = 0;
        }

        public bool Contains(T item)
        {
            for(int i = 0; i < _lastIndex; i++)
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
            for (int i = 0; i < _lastIndex; i++)
            {
                yield return _queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
