using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_по_К_Г__2_
{
    public class Matrix
    {
        public double [,] matrix;
        public Matrix(double a11, double a12, double a13, double a14, double a21, double a22, double a23, double a24, double a31, double a32, double a33, double a34, double a41, double a42, double a43, double a44)
        {
            this.matrix = new double[,]{
                { a11, a12, a13, a14 },
                { a21, a22, a23, a24 },
                { a31, a32, a33, a34 },
                { a41, a42, a43, a44 }
            };
        }
        public Matrix(double a11, double a12, double a13, double a14)
        {
             this.matrix = new double[,]
            {
            {a11, a12, a13, a14}
            };
        }
    }
}
