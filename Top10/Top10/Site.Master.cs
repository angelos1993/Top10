using System;
using System.Web.UI;
using Top10.BLL;
using Top10.DAL.Model;
using Top10.SessionManagement;
using Top10.Utility;

namespace Top10
{
    public partial class Site : MasterPage
    {
        #region Properties

        private SessionManager _sessionManager;
        private SessionManager SessionManager => _sessionManager ?? (_sessionManager = new SessionManager());
        private FeedbackManager _feedbackManager;
        private FeedbackManager FeedbackManager => _feedbackManager ?? (_feedbackManager = new FeedbackManager());

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

        protected void BtnSendFeedbach_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtFeedback.Text))
                return;
            FeedbackManager.AddFeedback(new Feedback
            {
                Message = TxtFeedback.Text,
                UserId = SessionManager.CurrentSessionObject.UserId
            });
        }

        #endregion

        #region Methods

        private void PageLoad()
        {
            LnkBtnLogout.Visible = SessionManager.CurrentSessionObject != null;
            DivFeedback.Visible = SessionManager.CurrentSessionObject != null;
        }

        #endregion
    }
}