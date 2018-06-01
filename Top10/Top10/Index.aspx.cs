using System;
using System.Web.UI;
using Top10.BLL;

namespace Top10
{
    public partial class Index : Page
    {
        #region Properties

        private UserManager _userManager;
        private UserManager UserManager => _userManager ?? (_userManager = new UserManager());

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_OnClick(object sender, EventArgs e)
        {
            var user = UserManager.Login(TxtUsername.Text, TxtPassword.Text);
            if (user != null)
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