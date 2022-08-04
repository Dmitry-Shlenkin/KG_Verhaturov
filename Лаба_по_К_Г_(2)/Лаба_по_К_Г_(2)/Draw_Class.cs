using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Лаба_по_К_Г__2_
{
    class Draw_Class
    {
        public void DrawAxis_complex(Graphics grr, Pen pen, (int, int)[] arr)
        {
            grr.DrawLine(pen, arr[10].Item1, arr[10].Item2, arr[11].Item1, arr[11].Item2);
            grr.DrawLine(pen, arr[12].Item1, arr[12].Item2, arr[13].Item1, arr[13].Item2);
        }

        public void DrawLines_complex(Graphics grr, Pen pen, (int, int)[] arr)
        {
            grr.DrawLine(pen, arr[5].Item1, arr[5].Item2, arr[4].Item1, arr[4].Item2);
            if (arr[5].Item1 != 150)
            {
                grr.DrawLine(pen, arr[6].Item1, arr[6].Item2, arr[0].Item1 , arr[0].Item2 );
                grr.DrawLine(pen, arr[6].Item1, arr[6].Item2, arr[5].Item1 , arr[5].Item2 );
            }
            grr.DrawLine(pen, arr[4].Item1, arr[4].Item2, arr[2].Item1, arr[2].Item2);

        }
        public void Paint_Dots_complex(Graphics grr, Pen pen, (int, int)[] arr)
        {
            for (byte i = 0; i < 14; i++)
            {
                grr.DrawEllipse(pen, (float)arr[i].Item1 - 3, (float)arr[i].Item2 - 3, 6, 6);
            }
        }
        public void Paint_Arc(Graphics grr, Pen pen, double dC, (int, int)[] arr,double CenterX,double CenterY)
        {
            if (arr[0].Item2 > CenterY)
            {
                grr.DrawArc(pen, (float)(CenterX - dC / 2), (float)(CenterY - dC / 2), (float)dC, (float)dC, 0, 90);
            }
        }

        public void Paint_Axis3D(Graphics grr, Pen Pen_Axis,double[,] Array2DPointsOrtogonal)
        {

            grr.DrawLine(Pen_Axis, (float)Array2DPointsOrtogonal[7, 0], (float)Array2DPointsOrtogonal[7, 1], (float)Array2DPointsOrtogonal[8, 0], (float)Array2DPointsOrtogonal[8, 1]);
            grr.DrawLine(Pen_Axis, (float)Array2DPointsOrtogonal[9, 0], (float)Array2DPointsOrtogonal[9, 1], (float)Array2DPointsOrtogonal[7, 0], (float)Array2DPointsOrtogonal[7, 1]);
            grr.DrawLine(Pen_Axis, (float)Array2DPointsOrtogonal[10, 0], (float)Array2DPointsOrtogonal[10, 1], (float)Array2DPointsOrtogonal[7, 0], (float)Array2DPointsOrtogonal[7, 1]);
        }
        public void Paint_Lines_Proection(Graphics grr, Pen Pen_Lines, double[,] Array2DPointsOrtogonal)
        {
            grr.DrawLine(Pen_Lines, (float)Array2DPointsOrtogonal[0, 0], (float)Array2DPointsOrtogonal[0, 1], (float)Array2DPointsOrtogonal[4, 0], (float)Array2DPointsOrtogonal[4, 1]);
            grr.DrawLine(Pen_Lines, (float)Array2DPointsOrtogonal[0, 0], (float)Array2DPointsOrtogonal[0, 1], (float)Array2DPointsOrtogonal[5, 0], (float)Array2DPointsOrtogonal[5, 1]);
            grr.DrawLine(Pen_Lines, (float)Array2DPointsOrtogonal[0, 0], (float)Array2DPointsOrtogonal[0, 1], (float)Array2DPointsOrtogonal[6, 0], (float)Array2DPointsOrtogonal[6, 1]);
            grr.DrawLine(Pen_Lines, (float)Array2DPointsOrtogonal[5, 0], (float)Array2DPointsOrtogonal[5, 1], (float)Array2DPointsOrtogonal[3, 0], (float)Array2DPointsOrtogonal[3, 1]);
            grr.DrawLine(Pen_Lines, (float)Array2DPointsOrtogonal[5, 0], (float)Array2DPointsOrtogonal[5, 1], (float)Array2DPointsOrtogonal[1, 0], (float)Array2DPointsOrtogonal[1, 1]);
            grr.DrawLine(Pen_Lines, (float)Array2DPointsOrtogonal[4, 0], (float)Array2DPointsOrtogonal[4, 1], (float)Array2DPointsOrtogonal[3, 0], (float)Array2DPointsOrtogonal[3, 1]);
            grr.DrawLine(Pen_Lines, (float)Array2DPointsOrtogonal[1, 0], (float)Array2DPointsOrtogonal[1, 1], (float)Array2DPointsOrtogonal[6, 0], (float)Array2DPointsOrtogonal[6, 1]);
            grr.DrawLine(Pen_Lines, (float)Array2DPointsOrtogonal[6, 0], (float)Array2DPointsOrtogonal[6, 1], (float)Array2DPointsOrtogonal[2, 0], (float)Array2DPointsOrtogonal[2, 1]);
            grr.DrawLine(Pen_Lines, (float)Array2DPointsOrtogonal[2, 0], (float)Array2DPointsOrtogonal[2, 1], (float)Array2DPointsOrtogonal[4, 0], (float)Array2DPointsOrtogonal[4, 1]);
        }
        public void Paint_dots_3D(Graphics grr, Pen Pen_Axis, double[,] Array2DPointsOrtogonal)
        {
            for (byte i = 0; i < Array2DPointsOrtogonal.GetLength(0); i++)
            {
                grr.DrawEllipse(Pen_Axis, (float)Array2DPointsOrtogonal[i, 0] - 3, (float)Array2DPointsOrtogonal[i, 1] - 3, 6, 6);
            }
        }
    }
}
