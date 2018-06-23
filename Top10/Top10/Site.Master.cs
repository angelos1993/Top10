using System;
using System.Web.UI;
using Top10.SessionManagement;
using Top10.Utility;

namespace Top10
{
    public partial class Site : MasterPage
    {
        #region Properties

        private SessionManager _sessionManager;
        private SessionManager SessionManager => _sessionManager ?? (_sessionManager = new SessionManager());

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }

        protected void LnkBtnLogout_OnClick(object sender, EventArgs e)
        {
            SessionManager.CurrentSessionObject = null;
            Response.Redirect(Constants.Pages.Index);
        }

        #endregion

        #region Methods

        private void PageLoad()
        {
            LnkBtnLogout.Visible = SessionManager.CurrentSessionObject != null;
        }

        #endregion
    }
}