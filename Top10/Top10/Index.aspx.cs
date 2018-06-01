using System;
using System.Web.UI;
using Top10.BLL;

namespace Top10
{
    public partial class Index : Page
    {
        #region Properties

        private StudentManager _studentManager;
        private StudentManager StudentManager => _studentManager ?? (_studentManager = new StudentManager());

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_OnClick(object sender, EventArgs e)
        {
            var student = StudentManager.Login(TxtUsername.Text, TxtPassword.Text);
            if (student != null)
            {

            }
            else
            {
                LblErrorMsg.Text = "من فضلك تأكد من الاسم والرقم السري";
                LblErrorMsg.Visible = true;
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}