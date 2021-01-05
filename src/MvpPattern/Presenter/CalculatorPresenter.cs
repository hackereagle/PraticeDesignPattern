using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpPattern.Presenter
{
    internal class CalculatorPresenter
    {
        private View.ICalculatorView mView;
        public CalculatorPresenter(View.ICalculatorView view)
        {
            mView = view;
            mView.ButtonClick += BtnClick;

            mCalculate = new Model.Calculator();
        }

        Model.Calculator mCalculate;
        private void BtnClick(object sender, EventArgs args)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
        }
    }
}
