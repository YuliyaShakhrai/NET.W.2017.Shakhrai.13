using System;

namespace CollectionMatrix
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region Constructor

        public DiagonalMatrix(int size) : base(size)
        {
        }

        #endregion

        #region Indexer

        public override T this[int i, int j]
        {
            get
            {
                return base[i, j];
            }

            set
            {
                if (i != j)
                {
                    throw new InvalidOperationException($"Element not on main diagonal must be default.");
                }

                base[i, j] = value;
            }
        }

        #endregion
    }
}
