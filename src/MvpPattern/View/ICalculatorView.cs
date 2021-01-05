using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpPattern.View
{
    public interface ICalculatorView
    {
        event EventHandler ButtonClick;
        string ResultText { set; get; }
    }
}
