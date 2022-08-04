using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_по_К_Г__2_
{
    class Calculate_Hard_Multiply
    {
        CalculateMatrix calculate = new CalculateMatrix();
        public double[,] Calculate_Ortogonal(double[,] Array4DPointsOrtogonal,double Xc,double Yc, double Zc,double CenterX,double CenterY  )
        {
            double Cos_A_Oz;
            double Sin_A_Oz;
            double Cos_B_Ox;
            double Sin_B_Ox;
            if (Yc == 0 && Xc == 0 )
            {
                Cos_A_Oz = 1;
                Sin_A_Oz = 0;
            }
            else
            {
                Cos_A_Oz = Yc / Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc, 2));
                Sin_A_Oz = Xc / Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc , 2));
            }
            if (Yc == 0 && Xc == 0 && Zc == 0)
            {
                Cos_B_Ox = 1;
                Sin_B_Ox = 0;
            }
            else
            {
                Cos_B_Ox = Zc  / Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc, 2) + Math.Pow(Zc, 2));
                Sin_B_Ox = Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc , 2)) / Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc, 2) + Math.Pow(Zc, 2));
            }
            Matrix matrixZ = new Matrix(Cos_A_Oz, Sin_A_Oz, 0, 0, -Sin_A_Oz, Cos_A_Oz, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            Matrix matrixX = new Matrix(1, 0, 0, 0, 0, Cos_B_Ox, Sin_B_Ox, 0, 0, -Sin_B_Ox, Cos_B_Ox, 0, 0, 0, 0, 1);
            double[,] Matrix_OZ = matrixZ.matrix;
            double[,] Matrix_OX = matrixX.matrix;
            double[,] Public_mass = calculate.calculateMatrix(Matrix_OZ, Matrix_OX);
            Matrix matrix_Mirrors = new Matrix(-1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            Matrix_OX = matrix_Mirrors.matrix;
            Matrix_OZ = calculate.calculateMatrix(Public_mass, Matrix_OX);
            Matrix matrix_Pz = new Matrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            Matrix_OX = matrix_Pz.matrix;
            Public_mass = calculate.calculateMatrix(Matrix_OZ, Matrix_OX);
            Matrix matrix_T = new Matrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, CenterX, CenterY, 0, 1);
            Matrix_OX = matrix_T.matrix;
            Matrix_OZ = calculate.calculateMatrix(Public_mass, Matrix_OX);

           double[,] Array2DPointsOrtogonal = calculate.calculateMatrix(Array4DPointsOrtogonal, Matrix_OZ);

            return Array2DPointsOrtogonal;
        }
        public double[,] Array_C_P(double[,] mass, double Xc, double Yc, double Zc, double CenterX, double CenterY)
        {
            double C = Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc, 2) + Math.Pow(Zc, 2));
            double Cos_A_Oz;
            double Sin_A_Oz;
            double Cos_B_Ox;
            double Sin_B_Ox;
            if (Yc == 0 && Xc == 0)
            {
                Cos_A_Oz = 1;
                Sin_A_Oz = 0;
            }
            else
            {
                Cos_A_Oz = Yc / Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc, 2));
                Sin_A_Oz = Xc / Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc, 2));
            }
            if (Yc == 0 && Xc == 0 && Zc == 0)
            {
                Cos_B_Ox = 1;
                Sin_B_Ox = 0;
            }
            else
            {
                Cos_B_Ox = Zc / Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc, 2) + Math.Pow(Zc, 2));
                Sin_B_Ox = Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc, 2)) / Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc, 2) + Math.Pow(Zc, 2));
            }

            Matrix matrixZ = new Matrix(Cos_A_Oz, Sin_A_Oz, 0, 0, -Sin_A_Oz, Cos_A_Oz, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            Matrix matrixX = new Matrix(1, 0, 0, 0, 0, Cos_B_Ox, Sin_B_Ox, 0, 0, -Sin_B_Ox, Cos_B_Ox, 0, 0, 0, 0, 1);

            double[,] Matrix_OZ = matrixZ.matrix;
            double[,] Matrix_OX = matrixX.matrix;
            double[,] Public_mass = calculate.calculateMatrix(Matrix_OZ, Matrix_OX);

            Matrix matrix_Mirrors = new Matrix(-1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            Matrix_OX = matrix_Mirrors.matrix;
            Matrix_OZ = calculate.calculateMatrix(Public_mass, Matrix_OX);
            Matrix matrixCz = new Matrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, -1 / C, 0, 0, 0, 1);
            Matrix_OX = matrixCz.matrix;
            Public_mass = calculate.calculateMatrix(Matrix_OZ, Matrix_OX);
            Matrix matrix_Pz = new Matrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            Matrix_OX = matrix_Pz.matrix;
            Matrix_OZ = calculate.calculateMatrix(Public_mass, Matrix_OX);
            Matrix matrix_T = new Matrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, CenterX, CenterY, 0, 1);
            Matrix_OX = matrix_T.matrix;

            Public_mass = calculate.calculateMatrix(Matrix_OZ, Matrix_OX);

           double[,] MassCenterProection = calculate.calculateMatrix(mass, Public_mass);
           double[,] Array2DPointsCenterProection = new double[11, 2];
            for (int i = 0; i < 11; i++)
            {
                Array2DPointsCenterProection[i, 0] = MassCenterProection[i, 0] / MassCenterProection[i, 3];
                Array2DPointsCenterProection[i, 1] = MassCenterProection[i, 1] / MassCenterProection[i, 3];
            }
            return Array2DPointsCenterProection;
        }
    }
}
