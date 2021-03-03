using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Type1Factory : IPointCornerFactory
    {
        private BarPointFactory mPointFactory;
        private PlusCornerFactory mCornerFactory;
        public Type1Factory()
        {
            mPointFactory = new BarPointFactory();
            mCornerFactory = new PlusCornerFactory();
        }


        IPoint IPointCornerFactory.GetPoint()
        {
            return mPointFactory;
        }

        ICorner IPointCornerFactory.GetCorner()
        {
            return mCornerFactory;
        }
    }

    public class BarPointFactory : IPoint
    {
        public BarPointFactory()
        { 
        }

        void IPoint.Line(int width)
        {
            for (int i = 0; i < width; i++)
                Console.Write("-");
        }
    }

    public class PlusCornerFactory : ICorner
    {
        public PlusCornerFactory()
        { 
        }

        void ICorner.LeftDown()
        {
            Console.Write("+");
        }

        void ICorner.LeftUp()
        {
            Console.Write("+");
        }

        void ICorner.RightDown()
        {
            Console.Write("+");
        }

        void ICorner.RightUp()
        {
            Console.Write("+");
        }
    }
}
