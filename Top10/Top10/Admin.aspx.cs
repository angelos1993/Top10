using System;
using System.Web.UI;
using Top10.BLL;
using Top10.SessionManagement;
using Top10.Utility;

namespace Top10
{
    public partial class Admin : Page
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
        }

        protected void BtnGeneratePasswordForUser_OnClick(object sender, EventArgs e)
        {
        }

        protected void BtnCurrentPasswordForUser_OnClick(object sender, EventArgs e)
        {
            if (int.TryParse(DdlUsers.SelectedValue, out int userId))
            {
                var pass = UserManager.GetUserPasswordById(userId);
                LblUserPassword.Text = $@"The Password is: {pass}";
                LblUserPassword.Visible = true;
            }
        }

        #endregion

        #region Methods

        private void PageLoad()
        {
            var currentSessionObject = SessionManager.CurrentSessionObject;
            if (currentSessionObject == null || !currentSessionObject.IsAdmin)
                Response.Redirect(Constants.Pages.Index);

            #region Fill Users' names to the drop down

            DdlUsers.DataSource = UserManager.GetAllUserNames();
            DdlUsers.DataTextField = "Value";
            DdlUsers.DataValueField= "Key";
            DdlUsers.DataBind();
            
            #endregion
        }

        #endregion
    }
}