using System;
using System.Collections.Generic;
using System.Linq;

namespace brain.business.mutant.Utility
{
    public class Array2nUtility<T>
    {
        public T[] GetColumn(T[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0)).Select(x => matrix[x, columnNumber]).ToArray();
        }

        public T[] GetRow(T[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1)).Select(x => matrix[rowNumber, x]).ToArray();
        }

        public List<string> GetDiagonals(T[,] matrix, int n)
        {
            string principal = string.Empty;
            string secondary = string.Empty;
            List<string> diagonals = new List<string>() { principal, secondary };

            for (int i = 0; i < n; i++)
            {
                principal += matrix[i, i];
                secondary += matrix[i, n - i - 1];
            }

            diagonals[0] = principal;
            diagonals[1] = secondary;

            return diagonals;
        }
    }
}
