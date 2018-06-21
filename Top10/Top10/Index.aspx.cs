using System;
using System.Web.UI;
using Top10.BLL;
using Top10.SessionManagement;
using Top10.Utility;

namespace Top10
{
    public partial class Index : Page
    {
        #region Properties

        private UserManager _userManager;
        private UserManager UserManager => _userManager ?? (_userManager = new UserManager());
        private SessionManager _sessionManager;
        private SessionManager SessionManager => _sessionManager ?? (_sessionManager = new SessionManager());

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
            #region Security Check

            var currentSessionObject = SessionManager.CurrentSessionObject;
            if (currentSessionObject != null)
            {
                Response.Redirect(GetUrlToRedirect(currentSessionObject));
                return;
            }

            #endregion

            LblErrorMsg.Visible = false;
        }

        private void Login()
        {
            var user = UserManager.Login(TxtUsername.Text, TxtPassword.Text);
            if (user != null)
            {
                SessionManager.CurrentSessionObject = new SessionObject(user);
                Response.Redirect(GetUrlToRedirect(SessionManager.CurrentSessionObject));
            }
            else
            {
                LblErrorMsg.Text = Resource.LoginFailedMsg;
                LblErrorMsg.Visible = true;
                TxtPassword.Text = string.Empty;
            }
        }

        private string GetUrlToRedirect(SessionObject currentSessionObject)
        {
            return currentSessionObject == null
                ? Constants.Pages.Index
                : (currentSessionObject.IsAdmin ? Constants.Pages.Admin : Constants.Pages.Quiz);
        }

        #endregion
    }
}