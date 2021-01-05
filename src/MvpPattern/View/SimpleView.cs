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
    // refer to https://social.msdn.microsoft.com/Forums/en-US/d35d2542-a30a-4ba8-9c30-b7a5550c2a0e/mvp-design-pattern-for-c-window-form?forum=winforms
    public partial class SimpleView : UserControl, ISimpleView
    {
        public SimpleView()
        {
            InitializeComponent();
            if (!Initialize())
                System.Windows.Forms.MessageBox.Show("SimpleView intialize fail!");
        }

        private Presenter.SimpleViewPresenter mPresenter;
        bool Initialize()
        {
            mPresenter = new Presenter.SimpleViewPresenter(this);

            this.btnCalculate.Click += BtnCalculateClick;
            return true;
        }

        public event EventHandler BtnCalculateClick;
        string ISimpleView.RadiusText
        {
            set { this.txtRadius.Text = value; }
            get { return this.txtRadius.Text; }
        }

        string ISimpleView.AreaText
        {
            set { this.txtArea.Text = value; }
            get { return this.txtArea.Text; }
        }
    }
}
