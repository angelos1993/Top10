using System;
using System.Web.UI;
using Top10.BLL;
using Top10.SessionManagement;
using Top10.Utility;

namespace Top10
{
    public partial class Quiz : Page
    {
        #region Properties

        private SessionManager _sessionManager;
        private SessionManager SessionManager => _sessionManager ?? (_sessionManager = new SessionManager());
        private DateTime Now => DateTime.Now;
        private UserGradeManager _userGradeManager;
        private UserGradeManager UserGradeManager => _userGradeManager ?? (_userGradeManager = new UserGradeManager());

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }

        #endregion

        #region Methods

        private void PageLoad()
        {
            #region Security Check

            var currentSessionObject = SessionManager.CurrentSessionObject;
            if (currentSessionObject == null)
            {
                Response.Redirect(Constants.Pages.Index);
                return;
            }

            #endregion

            HideAllSections();
            if (Now < Constants.StartDate)
            {
                //display the div that says the game will start on: [Constants.StartDate]
                DivBeforeStartDate.Visible = true;
            }
            else if (Now > Constants.EndDate)
            {
                //display the div that says the game ended on: [Constants.EndDate]
                DivAfterEndDate.Visible = true;
            }
            else
            {
                if (UserGradeManager.IsUserHasAnswersToday(currentSessionObject.UserId))
                {
                    //display the div that says: "you have answered the today's questions"
                    DivUserHadAnsweredToday.Visible = true;
                }
                else
                {
                    //new quiz
                    DivNewQuiz.Visible = true;
                }
            }
        }

        private void HideAllSections()
        {
            DivBeforeStartDate.Visible = false;
            DivAfterEndDate.Visible = false;
            DivUserHadAnsweredToday.Visible = false;
            DivNewQuiz.Visible = false;
        }

        #endregion
    }
}