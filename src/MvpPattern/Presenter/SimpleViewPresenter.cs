using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpPattern.Presenter
{
    public class SimpleViewPresenter
    {
        private View.ISimpleView mView;
        private Model.ICircleModel mCircleModel;
        public SimpleViewPresenter(View.ISimpleView view)
        {
            mView = view;
            mView.BtnCalculateClick += BtnCalculateClick;

            mCircleModel = new Model.CircleModel();
        }

        private void BtnCalculateClick(object sender, EventArgs args)
        {
            mView.AreaText = Math.Round(mCircleModel.GetArea(Convert.ToDouble(mView.RadiusText)), 2).ToString();
        }
    }
}
