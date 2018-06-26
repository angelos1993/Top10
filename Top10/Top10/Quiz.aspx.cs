using System;
using System.Web.UI;
using Top10.BLL;
using Top10.SessionManagement;
using Top10.Utility;
using static Top10.Utility.Constants;

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
        private UserTimeManager _userTimeManager;
        private UserTimeManager UserTimeManager => _userTimeManager ?? (_userTimeManager = new UserTimeManager());
        private QuestionManager _questionManager;
        private QuestionManager QuestionManager => _questionManager ?? (_questionManager = new QuestionManager());

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
            if (currentSessionObject == null || currentSessionObject.IsAdmin)
            {
                Response.Redirect(Pages.Index);
                return;
            }

            #endregion

            HideAllSections();
            if (Now < StartDate)
            {
                DivBeforeStartDate.Visible = true;
                LtrStartDate.Text = StartDate.ToShortDateString();
                SetImagesVisibility(true);
            }
            else if (Now > EndDate)
            {
                DivAfterEndDate.Visible = true;
                LtrEndDate.Text = EndDate.ToShortDateString();
                SetImagesVisibility(true);
            }
            else
            {
                if (UserGradeManager.IsUserHasAnswersToday(currentSessionObject.UserId))
                {
                    DivUserHadAnsweredToday.Visible = true;
                    SetImagesVisibility(true);
                }
                else if (UserTimeManager.IsUserTimeoutToday(currentSessionObject.UserId))
                {
                    DivUserTimeoutToday.Visible = true;
                    SetImagesVisibility(true);
                }
                else
                {
                    SetImagesVisibility(false);
                    //new quiz
                    var questionsIdsAnsweredByUser =
                        UserGradeManager.GetQuestionsIdsAnsweredByUser(currentSessionObject.UserId);
                    var todaysQuestions =
                        QuestionManager.GetQuestionsForUser(currentSessionObject.UserId, questionsIdsAnsweredByUser);
                    var time = UserTimeManager.GetUserTodaysTime(currentSessionObject.UserId);
                    if (time == 0)
                        time = Constants.Timer;
                    //TODO: display the three questions and set the timer
                    DivNewQuiz.Visible = true;
                }
            }
        }

        private void HideAllSections()
        {
            DivBeforeStartDate.Visible = false;
            DivAfterEndDate.Visible = false;
            DivUserHadAnsweredToday.Visible = false;
            DivUserTimeoutToday.Visible = false;
            DivNewQuiz.Visible = false;
        }

        private void SetImagesVisibility(bool isVisible)
        {
            ImgTop.Visible = isVisible;
            ImgBottom.Visible = isVisible;
        }

        #endregion
    }
}