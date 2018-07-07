using System;
using System.Collections.Generic;
using System.Web.UI;
using Top10.BLL;
using Top10.DAL.Model;
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
                if (user.IsAdmin)
                    SetSessionAndRedirect(user);
                else
                {
                    var loggedInUsers = Application["LoggedInUsers"] as List<int>;
                    if (loggedInUsers != null && loggedInUsers.Contains(user.Id))
                    {
                        DivAlreadyLoggedIn.Visible = true;
                        DivLogIn.Visible = false;
                    }
                    else
                    {
                        if (loggedInUsers == null)
                            loggedInUsers = new List<int>();
                        loggedInUsers.Add(user.Id);
                        Application["LoggedInUsers"] = loggedInUsers;
                        SetSessionAndRedirect(user);
                    }
                }
            }
            else
            {
                LblErrorMsg.Text = Resource.LoginFailedMsg;
                LblErrorMsg.Visible = true;
                TxtPassword.Text = string.Empty;
            }
        }

        private void SetSessionAndRedirect(User user)
        {
            SessionManager.CurrentSessionObject = new SessionObject(user);
            Response.Redirect(GetUrlToRedirect(SessionManager.CurrentSessionObject));
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