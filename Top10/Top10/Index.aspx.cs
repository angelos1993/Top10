using System;
using System.Web.UI;
using Top10.BLL;
using Top10.Utility;

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
            PageLoad();
        }

        protected void BtnLogin_OnClick(object sender, EventArgs e)
        {
            Login();
        }

        #endregion

        #region Methods

        private void PageLoad()
        {
        }

        private void Login()
        {
            var user = UserManager.Login(TxtUsername.Text, TxtPassword.Text);
            if (user != null)
            {
                //todo:set the session
                //Session[""] = user;
                Response.Redirect(Constants.Pages.Quiz);
            }
            else
            {
                LblErrorMsg.Text = Resource.LoginFailedMsg;
                LblErrorMsg.Visible = true;
            }
        }

        #endregion
    }
}