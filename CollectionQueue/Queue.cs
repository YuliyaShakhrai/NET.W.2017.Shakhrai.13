using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionQueue
{
    public class Queue<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>
    {
        #region Private fields

        private const int DefaultCapacity = 10;

        private const int ResizeCoefficient = 2;

        private T[] _queue;
        private int _size;
        private int _head;
        private int _tail;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a queue with a default capacity of 10.
        /// </summary>
        public Queue()
        {
            _queue = new T[DefaultCapacity];
        }

        /// <summary>
        /// Initializes the queue with the specified collection.
        /// </summary>
        /// <param name="collection">Input collection</param>
        public Queue(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException($"{nameof(collection)} is null.");
            }

            var enumerable = collection as T[] ?? collection.ToArray();
            _queue = new T[enumerable.Length];
            _size = _queue.Length;
            _tail = _size;
            Array.Copy(enumerable, _queue, _queue.Length);
        }

        /// <summary>
        /// Initializes a queue with a specified capacity.
        /// </summary>
        /// <param name="capacity">Capacity of queue</param>
        public Queue(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException($"{nameof(capacity)} must be greater than zero");
            }

            _queue = new T[capacity];
        }
        #endregion

        #region Public

        #endregion

        #region Interface implementations

        public int Count => _size;

        public object SyncRoot { get; } = new object();

        public bool IsSynchronized => false;

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Inserts item to the end of queue.
        /// </summary>
        public void Enqueue(T item)
        {
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException($"{nameof(item)} is null.");
            }

            if (_size == _queue.Length)
            {
                Array.Resize(ref _queue, _queue.Length * ResizeCoefficient);
            }

            _queue[_tail++] = item;
            _size++;
        }

        /// <summary>
        /// Returns an element from the beginning of the queue.
        /// </summary>
        public T Dequeue()
        {
            if (_queue.Length == 0)
            {
                throw new InvalidOperationException($"Queue is empty.");
            }

            var result = _queue[_head];
            _queue[_head++] = default(T);
            _size--;
            return result;
        }

        /// <summary>
        /// Clears the queue.
        /// </summary>
        public void Clear()
        {
            _head = 0;
            _tail = 0;
            _size = 0;
            Array.Clear(_queue, 0, _queue.Length);
        }

        /// <summary>
        /// Checks if an item exists in the queue.
        /// </summary>
        public bool Contains(T item)
        {
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException($"{nameof(item)} is null.");
            }

            return _queue.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the queue into a target array starting from index.
        /// </summary>
        /// <param name="array">Target array.</param>
        /// <param name="index">Start index.</param>
        public void CopyTo(T[] array, int index)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException(nameof(array));
            }

            if ((index < 0) || (index > array.Length))
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"{nameof(index)} must be between 0 and {array.Length}.");
            }

            Array.Copy(_queue, 0, array, index, _queue.Length);
        }

        /// <summary>
        /// Returns an element from the beginning of the queue but does not delete it.
        /// </summary>
        public T Peek()
        {
            if (_queue.Length == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _queue[_head];
        }

        /// <summary>
        /// Sets the capacity to the actual number of elements in the Queue<T>, if that number is less than 90 percent of current capacity.
        /// </summary>
        public void TrimExcess()
        {
            if (Count / _queue.Length < 0.9)
            {
                var newQueue = new T[_size];
                Array.Copy(_queue, _head, newQueue, 0, _size);
                _queue = newQueue;
            }
        }

        #region Private methods

        private T GetElement(int index) => _queue[index];

        #endregion

        #endregion

        #region Enumerator

        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            #region Private fields

            private readonly Queue<T> _queue;
            private int _index;
            private T _current;

            #endregion

            #region Constructor

            /// <summary>
            /// Initializes an instance of the enumerator for queue.
            /// </summary>
            public Enumerator(Queue<T> queue)
            {
                if (ReferenceEquals(queue, null))
                {
                    throw new ArgumentNullException($"nameof(queue) is null.");
                }

                _queue = queue;
                _index = -1;
                _current = default(T);
            }

            #endregion

            public T Current
            {
                get
                {
                    if (_index == -1)
                    {
                        throw new InvalidOperationException($"Enumeration not started.");
                    }

                    if (_index == -2)
                    {
                        throw new InvalidOperationException($"Enumeration is complete.");
                    }

                    return _current;
                }
            }
            
            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                _index = -2;
                _current = default(T);
            }

            public bool MoveNext()
            {
                if (_index == -2)
                {
                    return false;
                }

                if (++_index >= _queue._size)
                {
                    return false;
                }

                _current = _queue.GetElement(_index);
                return true;
            }

            public void Reset()
            {
                _index = -1;
                _current = default(T);
            }
        }

        #endregion
    }
}
