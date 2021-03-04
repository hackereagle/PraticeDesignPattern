using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Type2Factory : IPointCornerFactory
    {
        private S_ChrPointFactory mPointFactory;
        private C_ChrCornerFactory mCornerFactory;
        public Type2Factory()
        {
            mPointFactory = new S_ChrPointFactory();
            mCornerFactory = new C_ChrCornerFactory();
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

    public class S_ChrPointFactory : IPoint
    {
        public S_ChrPointFactory()
        { 
        }

        void IPoint.Line(int width)
        {
            for (int i = 0; i < width; i++)
                Console.Write("S");
        }
    }

    public class C_ChrCornerFactory : ICorner
    {
        public C_ChrCornerFactory()
        { 
        }

        void ICorner.LeftDown()
        {
            Console.Write("C");
        }

        void ICorner.LeftUp()
        {
            Console.Write("C");
        }

        void ICorner.RightDown()
        {
            Console.Write("C");
        }

        void ICorner.RightUp()
        {
            Console.Write("C");
        }
    }
}
