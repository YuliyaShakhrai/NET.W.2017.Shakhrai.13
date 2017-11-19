namespace CollectionMatrix
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        #region Constructor

        public SymmetricMatrix(int size) : base(size)
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
                base[i, j] = value;
                base[j, i] = value;
            }
        }

        #endregion
    }
}
