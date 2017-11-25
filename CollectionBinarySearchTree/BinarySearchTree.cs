using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionBinarySearchTree
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        #region Private fields

        private Node<T> _head;
        private IComparer<T> _comparer;
        private int _size;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of a Binary Tree with default comparer
        /// </summary>
        public BinarySearchTree()
        {
            _head = null;
            _size = 0;
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Creates a new instance of a Binary Tree with initialized comparer
        /// </summary>
        public BinarySearchTree(IComparer<T> comparer = null)
        {
            _head = null;
            _size = 0;
            if (comparer == null)
            {
                _comparer = Comparer<T>.Default;
            }

            _comparer = comparer;
        }

        /// <summary>
        /// Creates a new instance of a Binary Tree with specified elements and with specified comparer
        /// </summary>
        public BinarySearchTree(IEnumerable<T> items, IComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                _comparer = Comparer<T>.Default;
            }
            else
            {
                _comparer = comparer;
            }

            foreach (var item in items)
            {
                this.Insert(item);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the root of the tree (the top-most node)
        /// </summary>
        public Node<T> Root
        {
            get { return _head; }
            set { _head = value; }
        }

        /// <summary>
        /// Gets whether the tree is read-only
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the number of elements stored in the tree
        /// </summary>
        public int Count
        {
            get { return _size; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds a new element to the tree
        /// </summary>
        public void Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameof(value)} is null.");
            }

            Node<T> node = new Node<T>(value);
            Insert(node);
        }

        /// <summary>
        /// Adds a node to the tree
        /// </summary>
        public void Insert(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException($"{nameof(node)} is null.");
            }

            if (_head == null)
            {
                _head = node;
                node.Tree = this;
                _size++;
            }
            else
            {
                if (node.Parent == null)
                {
                    node.Parent = _head;
                }

                if (_comparer.Compare(node.Value, node.Parent.Value) <= 0)
                {
                    if (node.Parent.LeftChild == null)
                    {
                        node.Parent.LeftChild = node;
                        _size++;
                        node.Tree = this;
                    }
                    else
                    {
                        node.Parent = node.Parent.LeftChild;
                        Insert(node);
                    }
                }
                else
                {
                    if (node.Parent.RightChild == null)
                    {
                        node.Parent.RightChild = node;
                        _size++;
                        node.Tree = this;
                    }
                    else
                    {
                        node.Parent = node.Parent.RightChild;
                        Insert(node);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the first node in the tree with the parameter value.
        /// </summary>
        public Node<T> Find(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameof(value)} is null.");
            }

            Node<T> node = _head;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
                else
                {
                    if (_comparer.Compare(value, node.Value) < 0)
                    {
                        node = node.LeftChild;
                    }
                    else
                    {
                        node = node.RightChild;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Sets tree to zero
        /// </summary>
        public void Clear()
        {
            _head = null;
            _size = 0;
        }

        /// <summary>
        /// Removes all the elements stored in the tree
        /// </summary>
        public void MemberwiseClear()
        {
            foreach (T item in this.PostOrder())
            {
                this.Remove(item);
            }
        }

        /// <summary>
        /// Returns whether a value is stored in the tree
        /// </summary>
        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        /// <summary>
        /// Removes a value from the tree and returns whether the removal was successful.
        /// </summary>
        public void Remove(T value)
        {
            Node<T> removeNode = Find(value);
            Remove(removeNode);
        }

        /// <summary>
        /// Removes a node from the tree and returns whether the removal was successful.
        /// </summary>>
        public bool Remove(Node<T> removeNode)
        {
            if (removeNode == null || removeNode.Tree != this)
            {
                return false;
            }

            bool wasHead = removeNode == _head;

            if (Count == 1)
            {
                _head = null;
                removeNode.Tree = null;

                _size--;
            }
            else if (removeNode.IsLeaf)
            {
                if (removeNode.IsLeftChild)
                {
                    removeNode.Parent.LeftChild = null;
                }
                else
                {
                    removeNode.Parent.RightChild = null;
                }

                removeNode.Tree = null;
                removeNode.Parent = null;

                _size--;
            }
            else if (removeNode.ChildCount == 1)
            {
                if (removeNode.HasLeftChild)
                {
                    removeNode.LeftChild.Parent = removeNode.Parent;

                    if (wasHead)
                    {
                        Root = removeNode.LeftChild;
                    }

                    if (removeNode.IsLeftChild)
                    {
                        removeNode.Parent.LeftChild = removeNode.LeftChild;
                    }
                    else
                    {
                        removeNode.Parent.RightChild = removeNode.LeftChild;
                    }
                }
                else
                {
                    removeNode.RightChild.Parent = removeNode.Parent;

                    if (wasHead)
                    {
                        Root = removeNode.RightChild;
                    }

                    if (removeNode.IsLeftChild)
                    {
                        removeNode.Parent.LeftChild = removeNode.RightChild;
                    }
                    else
                    {
                        removeNode.Parent.RightChild = removeNode.RightChild;
                    }
                }

                removeNode.Tree = null;
                removeNode.Parent = null;
                removeNode.LeftChild = null;
                removeNode.RightChild = null;

                _size--;
            }
            else
            {
                Node<T> successorNode = removeNode.LeftChild;
                while (successorNode.RightChild != null)
                {
                    successorNode = successorNode.RightChild;
                }

                removeNode.Value = successorNode.Value;

                Remove(successorNode);
            }

            return true;
        }

        /// <summary>
        /// Returns an preorder-traversal enumerator for the tree values
        /// </summary>
        public IEnumerable<T> PreOrder()
        {
            return PreOrder(_head);
        }

        /// <summary>
        /// Returns a postorder-traversal enumerator for the tree values
        /// </summary>
        public IEnumerable<T> PostOrder()
        {
            return PostOrder(_head);
        }

        /// <summary>
        /// Returns an inorder-traversal enumerator for the tree values
        /// </summary>
        public IEnumerable<T> InOrder()
        {
            return InOrder(_head);
        }

        /// <summary>
        /// Returns an enumerator to scan through the elements stored in tree.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator to scan through the elements stored in tree.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Private methods

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Value;

            if (node.LeftChild != null)
            {
                foreach (var n in PreOrder(node.LeftChild))
                {
                    yield return n;
                }
            }

            if (node.RightChild != null)
            {
                foreach (var n in PreOrder(node.RightChild))
                {
                    yield return n;
                }
            }
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.LeftChild != null)
            {
                foreach (var n in InOrder(node.LeftChild))
                {
                    yield return n;
                }
            }

            yield return node.Value;

            if (node.RightChild != null)
            {
                foreach (var n in InOrder(node.RightChild))
                {
                    yield return n;
                }
            }
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.LeftChild != null)
            {
                foreach (var n in PostOrder(node.LeftChild))
                {
                    yield return n;
                }
            }

            if (node.RightChild != null)
            {
                foreach (var n in PostOrder(node.RightChild))
                {
                    yield return n;
                }
            }

            yield return node.Value;
        }

        #endregion
    }
}
