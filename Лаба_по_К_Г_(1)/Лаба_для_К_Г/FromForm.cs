using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Лаба_для_К_Г
{
    class FromForm
    {
        private int CenterX;
        private int CenterY;
        (int, int, int)[] baseStorage3DPoints;
        (int, int)[] storageSpacial2D;
        (int, int)[] storageComplex2D;
        public void Input(PictureBox pictureBox1, int x, int y, int z, int alpha, int beta, int gamma)
        {
            CenterX = pictureBox1.Size.Width / 2;
            CenterY = pictureBox1.Size.Height / 2;
            int lenAxis = (int)(Math.Min(CenterX, CenterY) - Math.Min(CenterX, CenterY) / 3);
            baseStorage3DPoints = new (int, int, int)[]
            {
                 (x, y, z),  (x, 0, 0), (0, y, 0),(0, 0, z),(0, y, z),(x, 0, z),(x, y, 0),(0, 0, 0),(lenAxis, 0, 0),
                 (-lenAxis, 0, 0),(0, lenAxis, 0),(0, -lenAxis, 0),(0, 0, lenAxis),(0, 0, -lenAxis)
            };
             storageSpacial2D = createstorageSpacial3D(baseStorage3DPoints, alpha, beta, gamma);
             storageComplex2D = createstorageSpacial2D(baseStorage3DPoints);
        }
        private (int, int)[] createstorageSpacial3D((int, int, int)[] baseStorage3DPoints, double alpha, double beta, double gamma)
        {
            storageSpacial2D = new (int, int)[14];
            for (byte i = 0; i < baseStorage3DPoints.Length; i++)
            {
                double tx = baseStorage3DPoints[i].Item1;
                double ty = baseStorage3DPoints[i].Item2;
                double tz = baseStorage3DPoints[i].Item3;
                double r_alpha = alpha * Math.PI / 180;
                double r_beta = beta * Math.PI / 180;
                double r_gamma = gamma * Math.PI / 180;

                int X = (int)(CenterX - tx * Math.Cos(r_alpha) - ty * Math.Cos(r_beta) - tz * Math.Cos(r_gamma));
                int Y = (int)(CenterY + tx * Math.Sin(r_alpha) + ty * Math.Cos(r_beta) + tz * Math.Sin(r_gamma));
                storageSpacial2D[i] = (X, Y);
            }
            return storageSpacial2D;
        }
        private (int, int)[] createstorageSpacial2D((int, int, int)[] baseStorage3DPoints)
        {
            storageComplex2D = new (int, int)[14];
            int XX = (int)(CenterX);
            int YYY = (int)(CenterY + baseStorage3DPoints[0].Item2);
            storageComplex2D[0] = (XX, YYY);
            for (byte i = 1; i < baseStorage3DPoints.Length; i++)
            {
                if (baseStorage3DPoints[i].Item3 == 0)
                {
                    int X = (int)(CenterX - baseStorage3DPoints[i].Item1);
                    int YY = (int)(CenterY + baseStorage3DPoints[i].Item2);
                    storageComplex2D[i] = (X, YY);
                }
                if (baseStorage3DPoints[i].Item2 == 0)
                {
                    int X = (int)(CenterX - baseStorage3DPoints[i].Item1);
                    int YY = (int)(CenterY - baseStorage3DPoints[i].Item3);
                    storageComplex2D[i] = (X, YY);
                }
                if (baseStorage3DPoints[i].Item1 == 0)
                {
                    int X = (int)(CenterX + baseStorage3DPoints[i].Item2);
                    int YY = (int)(CenterY - baseStorage3DPoints[i].Item3);
                    storageComplex2D[i] = (X, YY);
                }
            }
            return storageComplex2D;
        }
        public void PC1(PictureBox pictureBox)
        {
            pictureBox.Image = null;
            Bitmap bm = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics grr = Graphics.FromImage(bm))
            {
                Color col = Color.Black;
                grr.DrawLine(new Pen(col), storageSpacial2D[0].Item1 + 3, storageSpacial2D[0].Item2 + 3, storageSpacial2D[4].Item1 + 3, storageSpacial2D[4].Item2 + 3);
                grr.DrawLine(new Pen(col), storageSpacial2D[0].Item1 + 3, storageSpacial2D[0].Item2 + 3, storageSpacial2D[5].Item1 + 3, storageSpacial2D[5].Item2 + 3);
                grr.DrawLine(new Pen(col), storageSpacial2D[0].Item1 + 3, storageSpacial2D[0].Item2 + 3, storageSpacial2D[6].Item1 + 3, storageSpacial2D[6].Item2 + 3);
                grr.DrawLine(new Pen(col), storageSpacial2D[1].Item1 + 3, storageSpacial2D[1].Item2 + 3, storageSpacial2D[5].Item1 + 3, storageSpacial2D[5].Item2 + 3);
                grr.DrawLine(new Pen(col), storageSpacial2D[1].Item1 + 3, storageSpacial2D[1].Item2 + 3, storageSpacial2D[6].Item1 + 3, storageSpacial2D[6].Item2 + 3);
                grr.DrawLine(new Pen(col), storageSpacial2D[2].Item1 + 3, storageSpacial2D[2].Item2 + 3, storageSpacial2D[4].Item1 + 3, storageSpacial2D[4].Item2 + 3);
                grr.DrawLine(new Pen(col), storageSpacial2D[2].Item1 + 3, storageSpacial2D[2].Item2 + 3, storageSpacial2D[6].Item1 + 3, storageSpacial2D[6].Item2 + 3);
                grr.DrawLine(new Pen(col), storageSpacial2D[3].Item1 + 3, storageSpacial2D[3].Item2 + 3, storageSpacial2D[4].Item1 + 3, storageSpacial2D[4].Item2 + 3);
                grr.DrawLine(new Pen(col), storageSpacial2D[3].Item1 + 3, storageSpacial2D[3].Item2 + 3, storageSpacial2D[5].Item1 + 3, storageSpacial2D[5].Item2 + 3);
                grr.DrawLine(new Pen(col), storageSpacial2D[8].Item1 + 3, storageSpacial2D[8].Item2 + 3, storageSpacial2D[9].Item1 + 3, storageSpacial2D[9].Item2 + 3);
                grr.DrawLine(new Pen(col), storageSpacial2D[10].Item1 + 3, storageSpacial2D[10].Item2 + 3, storageSpacial2D[11].Item1 + 3, storageSpacial2D[11].Item2 + 3);
                grr.DrawLine(new Pen(col), storageSpacial2D[12].Item1 + 3, storageSpacial2D[12].Item2 + 3, storageSpacial2D[13].Item1 + 3, storageSpacial2D[13].Item2 + 3);
                for (byte i = 0; i < 8; i++)
                {
                    grr.DrawEllipse(new Pen(col), storageSpacial2D[i].Item1, storageSpacial2D[i].Item2, 6, 6);
                }
            }
            pictureBox.Image = bm;
        }
        public void PC2 (PictureBox pictureBox)
        {
            pictureBox.Image = null;
            Bitmap bm = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics grr = Graphics.FromImage(bm))
            {
                Color col = Color.Red;
                Color col1 = Color.Black;
                grr.DrawLine(new Pen(col1), storageComplex2D[8].Item1 + 3, storageComplex2D[8].Item2 + 3, storageComplex2D[9].Item1 + 3, storageComplex2D[9].Item2 + 3);
                grr.DrawLine(new Pen(col1), storageComplex2D[12].Item1 + 3, storageComplex2D[12].Item2 + 3, storageComplex2D[13].Item1 + 3, storageComplex2D[13].Item2 + 3);
               if (storageComplex2D[5].Item1 != CenterY)
                {
                    grr.DrawLine(new Pen(col), storageComplex2D[6].Item1 + 3, storageComplex2D[6].Item2 + 3, storageComplex2D[0].Item1 + 3, storageComplex2D[0].Item2 + 3);
                    grr.DrawLine(new Pen(col), storageComplex2D[6].Item1 + 3, storageComplex2D[6].Item2 + 3, storageComplex2D[5].Item1 + 3, storageComplex2D[5].Item2 + 3);

                }
                grr.DrawLine(new Pen(col), storageComplex2D[5].Item1 + 3, storageComplex2D[5].Item2 + 3, storageComplex2D[4].Item1 + 3, storageComplex2D[4].Item2 + 3);
                grr.DrawLine(new Pen(col), storageComplex2D[4].Item1 + 3, storageComplex2D[4].Item2 + 3, storageComplex2D[2].Item1 + 3, storageComplex2D[2].Item2 + 3);

                double d = (2 * Math.Abs(CenterX - storageComplex2D[0].Item2));


                if (storageComplex2D[0].Item2 < CenterY)
                {
                    grr.DrawArc(new Pen(col), (float)(CenterX - d / 2) + 3, (float)(CenterX - d / 2) + 3, (float)d, (float)d, 180, 90);
                }
                else if (storageComplex2D[0].Item2 > CenterY)
                {
                    grr.DrawArc(new Pen(col), (float)(CenterX - d / 2) + 3, (float)(CenterY - d / 2) + 3, (float)d, (float)d, 0, 90);

                }
                else
                {

                }
                for (byte i = 0; i < storageComplex2D.Length; i++)
                {
                    grr.DrawEllipse(new Pen(col), storageComplex2D[i].Item1, storageComplex2D[i].Item2, 6, 6);
                }
            }
            pictureBox.Image = bm;
        }
    }
}
