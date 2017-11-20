using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionBinarySearchTree
{
    public class Node<T> where T : IComparable<T>
    {
        #region Constructor

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        #endregion

        #region Properties

        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        #endregion
    }
}
