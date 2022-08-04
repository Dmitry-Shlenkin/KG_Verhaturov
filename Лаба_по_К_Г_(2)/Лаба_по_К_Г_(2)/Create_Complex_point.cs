using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_по_К_Г__2_
{
    class Create_Complex_point
    {
        public (int, int)[] CreateStorageComplex2D((int, int, int)[] baseStorage3DPoints, double CenterX, double CenterY)
        {
            (int, int)[] storageComplex2D = new (int, int)[14];

            int x =(int) CenterX;
            int y = (int)CenterY + baseStorage3DPoints[0].Item2;

            storageComplex2D[0] = (x, y);

            for (int i = 1; i < baseStorage3DPoints.Length; i++)
            {
                if (baseStorage3DPoints[i].Item1 == 0)
                {
                    x = (int)CenterX + baseStorage3DPoints[i].Item2;
                    y = (int)CenterY - baseStorage3DPoints[i].Item3;
                }
                else if (baseStorage3DPoints[i].Item2 == 0)
                {
                    x = (int)CenterX - baseStorage3DPoints[i].Item1;
                    y = (int)CenterY - baseStorage3DPoints[i].Item3;
                }
                else
                {
                    x = (int)CenterX - baseStorage3DPoints[i].Item1;
                    y = (int)CenterY + baseStorage3DPoints[i].Item2;
                }
                storageComplex2D[i] = (x, y);
            }
            return storageComplex2D;
        }
    }
}
