using System;

namespace CollectionMatrix
{
    public class SquareMatrix<T> 
    {
        #region Fields

        private T[,] matrix;

        #endregion

        #region Constructor

        public SquareMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException($"{nameof(size)} must be greater than 0.");
            }

            matrix = new T[size, size];
        }

        public SquareMatrix(T[,] sourceArray)
        {
            if (ReferenceEquals(sourceArray, null))
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            if (sourceArray.GetLength(0) != sourceArray.GetLength(1))
            {
                throw new ArgumentException($"{nameof(sourceArray)} is not square.");
            }

            int size = sourceArray.GetLength(0);

            matrix = new T[size, size];
            Array.Copy(sourceArray, matrix, this.Size * this.Size);
        }

        #endregion

        #region Event

        public event EventHandler<ElementChangeEventArgs> ElementChange;

        #endregion

        #region Properties

        public int Size => matrix.GetLength(0);

        #endregion

        #region Indexer

        /// <summary>
        /// Returns or sets the element in the matrix by i and j.
        /// </summary>
        public virtual T this[int i, int j]
        {
            get
            {
                ValidateIndexes(i, j);

                return matrix[i, j];
            }

            set
            {
                ValidateIndexes(i, j);

                matrix[i, j] = value;
                OnElementChange(this, new ElementChangeEventArgs(i, j));
            }
        }

        #endregion

        #region Event invoker

        /// <summary>
        /// Method that is called when the element in the matrix is changed.
        /// </summary>
        protected virtual void OnElementChange(object sender, ElementChangeEventArgs args)
        {
            var e = ElementChange;
            e?.Invoke(sender, args);
        }

        #endregion

        #region Private methods

        private void ValidateIndexes(int i, int j)
        {
            if (i < 0 || j < 0 || i >= matrix.Length || j >= matrix.Length)
            {
                throw new ArgumentOutOfRangeException($"Index cannot be less than zero or more than actual matrix length.");
            }
        }

        #endregion
    }
}
