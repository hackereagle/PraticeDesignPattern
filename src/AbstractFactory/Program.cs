using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Rectangle
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Paint(IPointCornerFactory factory)
        {
            IPoint point = factory.GetPoint();
            ICorner corner = factory.GetCorner();

            corner.LeftUp();
            point.Line(width - 2);
            corner.RightUp();
            Console.Write("\n");
            for (int i = 0; i < height - 2; i++)
            {
                point.Line(width);
                Console.Write("\n");
            }
            corner.LeftDown();
            point.Line(width - 2);
            corner.RightDown();
            Console.Write("\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(20, 10);
            IPointCornerFactory factory = new Type1Factory();
            rect.Paint(factory);

            Console.ReadLine();
        }
    }
}
