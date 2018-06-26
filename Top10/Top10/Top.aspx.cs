using System;
using System.Web.UI;
using Top10.SessionManagement;
using Top10.Utility;

namespace Top10
{
    public partial class Top : Page
    {
        private SessionManager _sessionManager;
        private SessionManager SessionManager => _sessionManager ?? (_sessionManager = new SessionManager());

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Security Check

            var currentSessionObject = SessionManager.CurrentSessionObject;
            if (currentSessionObject == null || currentSessionObject.IsAdmin)
            {
                Response.Redirect(Constants.Pages.Index);
            }

            #endregion
        }
    }
}