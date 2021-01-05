using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpPattern.Model
{
    class CircleModel : ICircleModel
    {
        double ICircleModel.GetArea(double radius)
        {
            return Math.PI * radius * radius;
        }
    }
}
