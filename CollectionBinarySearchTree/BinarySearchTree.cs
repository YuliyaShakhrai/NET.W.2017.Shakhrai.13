using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionBinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        #region Properties

        public Node<T> Root { get; set; } = null;

        #endregion

        #region Public methods

        public void Insert(T value)
        {
            var node = new Node<T>(value);
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                var current = Root;
                while (true)
                {
                    int result = value.CompareTo(current.Value);
                    if (result == 0)
                    {
                        current.Value = value;
                        return;
                    }
                    else if (result < 0)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            return;
                        }
                    }
                }
            }
        }

        public Node<T> Find(T value)
        {
            var current = Root;

            while (current.Value.CompareTo(value) != 0)
            {
                if (current.Value.CompareTo(value) > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }

                if (current == null)
                {
                    return null;
                }
            }

            return current;
        }

        public void Remove(T value)
        {

        }

        #endregion
    }
}
