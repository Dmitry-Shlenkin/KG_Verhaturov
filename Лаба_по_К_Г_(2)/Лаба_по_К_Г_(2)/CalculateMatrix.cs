using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_по_К_Г__2_
{
    class CalculateMatrix
    {
        public double[,] calculateMatrix(double[,] matrix_A, double[,] matrix_B)
        {
            double[,] Public_Matrix = new double[matrix_A.GetLength(0), matrix_A.GetLength(1)];
            for (int row = 0; row <matrix_A.GetLength(0); row++)
            {
                for (int col = 0; col < matrix_B.GetLength(1); col++)
                {
                    for (int i = 0; i < matrix_A.GetLength(1); i++)
                    {
                        Public_Matrix[row, col] += matrix_A[row, i] * matrix_B[i, col];
                    }
                }
            }
            return Public_Matrix;
        }
    }
}
