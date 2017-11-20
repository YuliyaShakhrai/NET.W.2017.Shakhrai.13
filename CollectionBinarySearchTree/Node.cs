using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionBinarySearchTree
{
    /// <summary>
    /// A Binary Tree node that holds an element and references to other tree nodes
    /// </summary>
    public class Node<T> where T : IComparable<T>
    {
        #region Private fields

        private T _value;
        private Node<T> _leftChild;
        private Node<T> _rightChild;
        private Node<T> _parent;
        private BinarySearchTree<T> _tree;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of a Binary Tree node
        /// </summary>
        public Node(T value)
        {
            _value = value;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// The value stored at the node
        /// </summary>
        public virtual T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Gets or sets the left child node
        /// </summary>
        public virtual Node<T> LeftChild
        {
            get { return _leftChild; }
            set { _leftChild = value; }
        }

        /// <summary>
        /// Gets or sets the right child node
        /// </summary>
        public virtual Node<T> RightChild
        {
            get { return _rightChild; }
            set { _rightChild = value; }
        }

        /// <summary>
        /// Gets or sets the parent node
        /// </summary>
        public virtual Node<T> Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        /// <summary>
        /// Gets or sets the Binary Tree the node belongs to
        /// </summary>
        public virtual BinarySearchTree<T> Tree
        {
            get { return _tree; }
            set { _tree = value; }
        }

        /// <summary>
        /// Gets whether the node is a leaf (has no children)
        /// </summary>
        public virtual bool IsLeaf
        {
            get { return ChildCount == 0; }
        }

        /// <summary>
        /// Gets whether the node is internal (has children nodes)
        /// </summary>
        public virtual bool IsInternal
        {
            get { return ChildCount > 0; }
        }

        /// <summary>
        /// Gets whether the node is the left child of its parent
        /// </summary>
        public virtual bool IsLeftChild
        {
            get { return Parent != null && Parent.LeftChild == this; }
        }

        /// <summary>
        /// Gets whether the node is the right child of its parent
        /// </summary>
        public virtual bool IsRightChild
        {
            get { return Parent != null && Parent.RightChild == this; }
        }

        /// <summary>
        /// Gets the number of children this node has
        /// </summary>
        public virtual int ChildCount
        {
            get
            {
                int count = 0;

                if (LeftChild != null)
                {
                    count++;
                }

                if (RightChild != null)
                {
                    count++;
                }

                return count;
            }
        }

        /// <summary>
        /// Gets whether the node has a left child node
        /// </summary>
        public virtual bool HasLeftChild
        {
            get { return LeftChild != null; }
        }

        /// <summary>
        /// Gets whether the node has a right child node
        /// </summary>
        public virtual bool HasRightChild
        {
            get { return RightChild != null; }
        }

        #endregion
    }
}
