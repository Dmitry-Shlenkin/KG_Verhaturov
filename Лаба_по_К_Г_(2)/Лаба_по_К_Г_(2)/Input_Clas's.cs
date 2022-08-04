using System;
using System.Drawing;
using System.Windows.Forms;

namespace Лаба_по_К_Г__2_
{
    class Input_Class
    {
        Calculate_Hard_Multiply calculate_Hard_Multiply = new Calculate_Hard_Multiply();
        Draw_Class Draw_Class = new Draw_Class();
        double CenterX;
        double CenterY;
        double[,] Array4DPointsOrtogonal;
        double[,] Array2DPointsOrtogonal;
        double[,] Array2DPointsCenterProection;
        (int, int)[] storageComplex2DPoint_C;
        (int, int)[] storageComplex2DPoint_T;
        byte IsOrtogonal;

        public void Input(PictureBox pc, int x, int y, int z, int Xc, int Yc, int Zc, RadioButton radioButton)
        {
            double C = Math.Sqrt(Math.Pow(Xc, 2) + Math.Pow(Yc, 2) + Math.Pow(Zc, 2));
            CenterX = pc.Size.Width / 2;
            CenterY = pc.Size.Height / 2;
            int lenAxis = (int)(Math.Min(CenterX, CenterY) - Math.Min(CenterX, CenterY) / 3);

            Array4DPointsOrtogonal = new double[11, 4]
            {
              {x, y, z, 1},{x, 0, 0, 1},{0, y, 0, 1},{0, 0, z, 1},{0, y, z, 1},{x, 0, z, 1},
              { x, y, 0, 1},{ 0, 0, 0, 1},{lenAxis, 0, 0, 1},{0, lenAxis, 0, 1},{0, 0, lenAxis, 1}
            };
            (int, int, int)[] baseStorage3DPoints_C = 
                {
                (Xc, Yc, Zc),(Xc, 0, 0),(0, Yc, 0),(0, 0, Zc),(0, Yc, Zc),(Xc, 0, Zc),(Xc, Yc, 0),
                (0, 0, 0),(lenAxis, 0, 0),(-lenAxis, 0, 0),(0, lenAxis, 0),(0, -lenAxis, 0),
                (0, 0, lenAxis),(0, 0, -lenAxis),
             };
            (int, int, int)[] baseStorage3DPoints_T = 
                {
                (x, y, z),(x, 0, 0),(0, y, 0),(0, 0, z),(0, y, z),(x, 0, z),(x, y, 0),
                (0, 0, 0),(lenAxis, 0, 0),(-lenAxis, 0, 0),(0, lenAxis, 0),(0, -lenAxis, 0),
                (0, 0, lenAxis),(0, 0, -lenAxis),
             };

            Create_Complex_point create_Complex_Point = new Create_Complex_point();
            storageComplex2DPoint_C = create_Complex_Point.CreateStorageComplex2D(baseStorage3DPoints_C, CenterX, CenterY);
            storageComplex2DPoint_T = create_Complex_Point.CreateStorageComplex2D(baseStorage3DPoints_T, CenterX, CenterY);

            if (radioButton.Checked)
            {
                if (Prove(Xc, Yc, Zc) == true)
                {
                    IsOrtogonal = 1;
                    Array2DPointsOrtogonal = calculate_Hard_Multiply.Calculate_Ortogonal(Array4DPointsOrtogonal, Xc, Yc, Zc, CenterX, CenterY);
                }
            }
            else
            {
                bool k = true;
                if (Prove_center(Xc, Yc, Zc, x, y, z) == true)
                {
                    IsOrtogonal = 0;
                    Array2DPointsCenterProection = calculate_Hard_Multiply.Array_C_P(Array4DPointsOrtogonal, Xc, Yc, Zc, CenterX, CenterY);
                     for (byte i = 0; i < Array2DPointsCenterProection.GetLength(0)-3; i++)
                     {
                        if ((Array2DPointsCenterProection[i, 0] < 0 || Array2DPointsCenterProection[i, 0] > pc.Width) || (Array2DPointsCenterProection[i, 1] < 0 || Array2DPointsCenterProection[i, 1] > pc.Height))
                        {
                            k = false;
                        }
                     } 
                }
                if (k == false)
                {
                    MessageBox.Show("Ошибка: Точка вышла за пределы экрана");
                }
            }            
        }

        public void Paint_Ortogonal(PictureBox pc)
        {
            Pen Pen_Axis = new Pen(Color.Black);
            Pen Pen_Lines = new Pen(Color.Red);
            if (IsOrtogonal == 1)
            {
                pc.Image = null;
                Bitmap bm = new Bitmap(pc.Width, pc.Height);
                using (Graphics grr = Graphics.FromImage(bm))
                {
                    Draw_Class.Paint_Axis3D(grr, Pen_Axis, Array2DPointsOrtogonal);
                    Draw_Class.Paint_Lines_Proection(grr, Pen_Lines, Array2DPointsOrtogonal);

                    Draw_Class.Paint_dots_3D(grr, Pen_Axis, Array2DPointsOrtogonal);
                }
                pc.Image = bm;
            }
            else
            {
                pc.Image = null;
                Bitmap bm = new Bitmap(pc.Width, pc.Height);
                using (Graphics grr = Graphics.FromImage(bm))
                {
                    Draw_Class.Paint_Axis3D(grr, Pen_Axis, Array2DPointsCenterProection);
                    Draw_Class.Paint_Lines_Proection(grr, Pen_Lines, Array2DPointsCenterProection);

                    Draw_Class.Paint_dots_3D(grr, Pen_Axis, Array2DPointsCenterProection);
                }
                pc.Image = bm;
            }
        }
        public void PaintComplex(PictureBox pc)
        {
            double dC = (2 * Math.Abs(CenterX - storageComplex2DPoint_C[0].Item2));
            double dT = (2 * Math.Abs(CenterX - storageComplex2DPoint_T[0].Item2));
            pc.Image = null;
            Bitmap bm = new Bitmap(pc.Width, pc.Height);
            using (Graphics grr = Graphics.FromImage(bm))
            {
                Pen Pen_Axis = new Pen(Color.Black, 1.5f);
                Pen Pen_Lines_Green = new Pen(Color.Green, 1.5f);
                Pen Pen_Lines_Black = new Pen(Color.Black, 1);

                Draw_Class.DrawAxis_complex(grr, Pen_Axis, storageComplex2DPoint_T);

                Draw_Class.DrawLines_complex(grr, Pen_Lines_Black, storageComplex2DPoint_T);
                Draw_Class.DrawLines_complex(grr, Pen_Lines_Green, storageComplex2DPoint_C);

                Draw_Class.Paint_Dots_complex(grr, Pen_Lines_Green, storageComplex2DPoint_C);
                Draw_Class.Paint_Dots_complex(grr, Pen_Lines_Black, storageComplex2DPoint_T);

                Draw_Class.Paint_Arc(grr, Pen_Lines_Green, dC, storageComplex2DPoint_C, CenterX, CenterY);
                Draw_Class.Paint_Arc(grr, Pen_Lines_Black, dT, storageComplex2DPoint_T, CenterX, CenterY);
            }
            pc.Image = bm;
        }
      
          private  bool Prove_center(int Xc, int Yc, int Zc,int x,int y,int z)
          {
                if (Xc == 0 && Yc == 0 && Zc == 0)
                {
                    MessageBox.Show("Ошибка: Неправильно задали координаты для точки С");
                    return false;
                }
                else if (-Xc * (x - Xc) - Yc * (y - Yc) - Zc * (z - Zc) <= 0)
                {
                    MessageBox.Show("Ошибка: Проекция неопределена");
                    return false;
                }
                else if (x == Xc && y == Yc && z == Zc)
                {
                    MessageBox.Show("Ошибка: Координаты точек Т и С совпали, проекцию построить невозможно");
                    return false;
                }
                else
                {
                    return true;
                }
          }
        private bool Prove(double Xc, double Yc, double Zc)
        {
            if (Xc == 0 && Yc == 0 && Zc == 0)
            {
                MessageBox.Show("Ошибка: Не задан вектор С");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

