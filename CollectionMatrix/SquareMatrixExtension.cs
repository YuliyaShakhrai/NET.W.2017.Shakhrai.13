using System;

namespace CollectionMatrix
{
    public static class SquareMatrixExtension
    {
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> matrix, SquareMatrix<T> addMatrix)
        {
                return matrix.Add(addMatrix, (arg1, arg2) => (dynamic)arg1 + (dynamic)arg2);
        }

        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> matrix, SquareMatrix<T> addMatrix, Func<T, T, T> sum)
        {
            ValidateParameters(matrix, addMatrix, sum);

            if (matrix.Size != addMatrix.Size)
            {
                throw new InvalidOperationException("Can not sum matrixes with different size.");
            }

            var resultArray = new T[matrix.Size, matrix.Size];

            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    resultArray[i, j] = sum(matrix[i, j], addMatrix[i, j]);
                }
            }

            return new SquareMatrix<T>(resultArray);
        }

        private static void ValidateParameters<T>(SquareMatrix<T> matrix, SquareMatrix<T> addMatrix, Func<T, T, T> addFunc)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException($"{nameof(matrix)} is null.");
            }

            if (addMatrix == null)
            {
                throw new ArgumentNullException($"{nameof(addMatrix)} is null.");
            }

            if (addFunc == null)
            {
                throw new ArgumentNullException($"{nameof(addFunc)} is null.");
            }
        }
    }
}
