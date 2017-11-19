using System;

namespace CollectionMatrix
{
    public class ElementChangeEventArgs : EventArgs
    {
        #region Constructor

        public ElementChangeEventArgs(int rowIndex, int columnIndex)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Index of row where element was changed.
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        /// Index of column where element was changed.
        /// </summary>
        public int ColumnIndex { get; }

        #endregion
    }
}
