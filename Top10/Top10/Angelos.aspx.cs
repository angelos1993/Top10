using System;
using System.Web.UI;
using Top10.BLL;
using Top10.SessionManagement;
using Top10.Utility;

namespace Top10
{
    public partial class Angelos : Page
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

        protected void BtnGeneratePasswordsForAllUsers_OnClick(object sender, EventArgs e)
        {
            UserManager.GeneratePasswordsForAllUsers();
        }

        #endregion

        #region Methods

        private void PageLoad()
        {
            #region Security Check

            var currentSessionObject = SessionManager.CurrentSessionObject;
            if (currentSessionObject == null || currentSessionObject.UserId != 2)
                Response.Redirect(Constants.Pages.Index);

            #endregion
        }

        #endregion
    }
}