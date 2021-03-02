using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    interface IPoint
    {
        void Line(int width);
    }

    interface ICorner
    {
        void LeftUp();
        void RightUp();
        void LeftDown();
        void RightDown();
    }

    interface IPointCornerFactory
    {
        IPoint GetPoint();
        ICorner GetCorner();
    }
}
