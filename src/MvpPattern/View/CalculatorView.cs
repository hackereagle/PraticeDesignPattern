using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MvpPattern.View
{
    public partial class CalculatorView : UserControl, ICalculatorView
    {
        public CalculatorView()
        {
            InitializeComponent();

            if (!Initialize())
                throw new Exception("Initialize Fail!");
        }

        private bool Initialize()
        {
            this.btnOne.Click += ButtonClick;
            this.btnTwo.Click += ButtonClick;
            this.btnThree.Click += ButtonClick;
            this.btnFour.Click += ButtonClick;
            this.btnFive.Click += ButtonClick;
            this.btnSix.Click += ButtonClick;
            this.btnSeven.Click += ButtonClick;
            this.btnEight.Click += ButtonClick;
            this.btnNine.Click += ButtonClick;
            this.btnDivide.Click += ButtonClick;
            this.btnMultiple.Click += ButtonClick;
            this.btnMinus.Click += ButtonClick;
            this.btnPlus.Click += ButtonClick;
            this.btnDot.Click += ButtonClick;

            return true;
        }

        public event EventHandler ButtonClick;
    }
}
