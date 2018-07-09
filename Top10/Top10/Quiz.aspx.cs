using System;
using System.Collections.Generic;
using System.Web.UI;
using Top10.BLL;
using Top10.DAL.Model;
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

        protected void BtnSubmitAnswers_OnClick(object sender, EventArgs e)
        {
            SubmitAnswers();
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

            if (!IsPostBack)
            {
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
                    var userTodaysTime = UserTimeManager.GetUserTodaysTime(currentSessionObject.UserId);
                    if (UserGradeManager.IsUserHasAnswersToday(currentSessionObject.UserId))
                    {
                        DivUserHadAnsweredToday.Visible = true;
                        SetImagesVisibility(true);
                    }
                    else if (userTodaysTime >= Constants.Timer)
                    {
                        DivUserTimeoutToday.Visible = true;
                        SetImagesVisibility(true);
                    }
                    else
                    {
                        SetImagesVisibility(false);
                        var questionsIdsAnsweredByUser =
                            UserGradeManager.GetQuestionsIdsAnsweredByUser(currentSessionObject.UserId);
                        var todaysQuestions =
                            QuestionManager.GetQuestionsForUser(currentSessionObject.UserId,
                                questionsIdsAnsweredByUser);
                        currentSessionObject.QuestionsList = todaysQuestions;
                        RepQuestions.DataSource = todaysQuestions;
                        RepQuestions.DataBind();
                        userTodaysTime = Constants.Timer - userTodaysTime;
                        HfTimer.Value = userTodaysTime.ToString();
                        DivNewQuiz.Visible = true;
                    }
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

        private void SubmitAnswers()
        {
            var currentSessionObject = SessionManager.CurrentSessionObject;
            var todaysQuestions = currentSessionObject.QuestionsList;
            var todaysUserGrades = new List<UserGrade>
            {
                new UserGrade
                {
                    Date = DateTime.Now,
                    UserId = currentSessionObject.UserId,
                    QuestionId = todaysQuestions[0].Id,
                    Answer = HfQuestion1Answer.Value,
                    Grade = HfQuestion1Answer.Value == todaysQuestions[0].CorrectChoice.Trim() ? todaysQuestions[0].Mark : 0
                },
                new UserGrade
                {
                    Date = DateTime.Now,
                    UserId = currentSessionObject.UserId,
                    QuestionId = todaysQuestions[1].Id,
                    Answer = HfQuestion2Answer.Value,
                    Grade = HfQuestion2Answer.Value == todaysQuestions[1].CorrectChoice.Trim() ? todaysQuestions[1].Mark : 0
                },
                new UserGrade
                {
                    Date = DateTime.Now,
                    UserId = currentSessionObject.UserId,
                    QuestionId = todaysQuestions[2].Id,
                    Answer = HfQuestion3Answer.Value,
                    Grade = HfQuestion3Answer.Value == todaysQuestions[2].CorrectChoice.Trim() ? todaysQuestions[2].Mark : 0
                }
            };
            UserGradeManager.AddUserAnswers(todaysUserGrades);
            Response.Redirect(Request.RawUrl);
        }

        #endregion
    }
}