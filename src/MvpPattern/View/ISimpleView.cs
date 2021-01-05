using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpPattern.View
{
    public interface ISimpleView
    {
        event EventHandler BtnCalculateClick;
        string RadiusText { get; set; }
        string AreaText { get; set; }
    }
}
