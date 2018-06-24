using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Top10.BLL;
using Top10.DAL.Model;
using Top10.DAL.VMs;
using Top10.SessionManagement;
using Top10.Utility;
using static Top10.Utility.PasswordUtility;

namespace Top10
{
    public partial class Admin : Page
    {
        #region Properties

        private UserManager _userManager;
        private UserManager UserManager => _userManager ?? (_userManager = new UserManager());
        private SessionManager _sessionManager;
        private SessionManager SessionManager => _sessionManager ?? (_sessionManager = new SessionManager());
        private List<User> _allUsers;
        private List<User> AllUsers => _allUsers ?? (_allUsers = UserManager.GetAllUsers().ToList());
        private FeedbackManager _feedbackManager;
        private FeedbackManager FeedbackManager => _feedbackManager ?? (_feedbackManager = new FeedbackManager());

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }

        protected void BtnGeneratePasswordForUser_OnClick(object sender, EventArgs e)
        {
            if (!int.TryParse(DdlUsers.SelectedValue, out int userId))
                return;
            var user = AllUsers.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return;
            user.Password = GetUniqueRandomPassword();
            UserManager.UpdateUser(user);
            DivPasswordCreatedSuccessfully.Visible = true;
            DisplayUser(user);
        }

        protected void BtnCurrentUserInfo_OnClick(object sender, EventArgs e)
        {
            if (!int.TryParse(DdlUsers.SelectedValue, out int userId))
                return;
            var user = AllUsers.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return;
            DisplayUser(user);
        }

        protected void DdlUserTypes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            List<KeyValuePair<int, string>> usersList;
            switch (DdlUserTypes.SelectedValue)
            {
                case "1":
                    usersList = AllUsers.Where(user => !user.IsAdmin && user.IsMale == true && user.Year == 1)
                        .Select(user => new KeyValuePair<int, string>(user.Id, user.ArabicName))
                        .OrderBy(keyValuePair => keyValuePair.Value).ToList();
                    break;
                case "2":
                    usersList = AllUsers.Where(user => !user.IsAdmin && user.IsMale == false && user.Year == 1)
                        .Select(user => new KeyValuePair<int, string>(user.Id, user.ArabicName))
                        .OrderBy(keyValuePair => keyValuePair.Value).ToList();
                    break;
                case "3":
                    usersList = AllUsers.Where(user => !user.IsAdmin && user.IsMale == true && user.Year == 2)
                        .Select(user => new KeyValuePair<int, string>(user.Id, user.ArabicName))
                        .OrderBy(keyValuePair => keyValuePair.Value).ToList();
                    break;
                case "4":
                    usersList = AllUsers.Where(user => !user.IsAdmin && user.IsMale == false && user.Year == 2)
                        .Select(user => new KeyValuePair<int, string>(user.Id, user.ArabicName))
                        .OrderBy(keyValuePair => keyValuePair.Value).ToList();
                    break;
                case "5":
                    usersList = AllUsers.Where(user => !user.IsAdmin && user.IsMale == true && user.Year == 3)
                        .Select(user => new KeyValuePair<int, string>(user.Id, user.ArabicName))
                        .OrderBy(keyValuePair => keyValuePair.Value).ToList();
                    break;
                case "6":
                    usersList = AllUsers.Where(user => !user.IsAdmin && user.IsMale == false && user.Year == 3)
                        .Select(user => new KeyValuePair<int, string>(user.Id, user.ArabicName))
                        .OrderBy(keyValuePair => keyValuePair.Value).ToList();
                    break;
                default:
                    usersList = AllUsers.Where(user => !user.IsAdmin)
                        .Select(user => new KeyValuePair<int, string>(user.Id, user.ArabicName))
                        .OrderBy(keyValuePair => keyValuePair.Value).ToList();
                    break;
            }
            DisplayUsersAtDropDown(usersList);
        }

        #endregion

        #region Methods

        private void PageLoad()
        {
            #region Security Check

            var currentSessionObject = SessionManager.CurrentSessionObject;
            if (currentSessionObject == null || !currentSessionObject.IsAdmin)
            {
                Response.Redirect(Constants.Pages.Index);
                return;
            }

            #endregion

            if (!IsPostBack)
            {
                #region Fill Users' names to the drop down

                DisplayUsersAtDropDown(AllUsers.Where(user => !user.IsAdmin)
                    .Select(user => new KeyValuePair<int, string>(user.Id, user.ArabicName))
                    .OrderBy(keyValuePair => keyValuePair.Value).ToList());

                #endregion

                #region Top Users

                #endregion

                #region Users' feedbacks

                var allFeedbacks = FeedbackManager.GetAllFeedbacks();
                if (allFeedbacks.Any())
                {
                    DivFeedbacks.Visible = true;
                    DivNoFeedbacks.Visible = false;
                    RepFeedbacks.DataSource = allFeedbacks.Select(feedback => new FeedbackVm
                    {
                        Username = UserManager.GetUsernameById(feedback.UserId),
                        Message = feedback.Message
                    });
                    RepFeedbacks.DataBind();
                }
                else
                {
                    DivFeedbacks.Visible = false;
                    DivNoFeedbacks.Visible = true;
                }

                #endregion
            }
            DivPasswordCreatedSuccessfully.Visible = false;
        }

        private void DisplayUsersAtDropDown(List<KeyValuePair<int, string>> usersList)
        {
            DdlUsers.DataSource = usersList;
            DdlUsers.DataTextField = "Value";
            DdlUsers.DataValueField = "Key";
            DdlUsers.DataBind();
        }

        private void DisplayUser(User user)
        {
            TblUserInfo.Visible = true;
            LtrUserArabicName.Text = user.ArabicName;
            LtrUserEnglishName.Text = user.EnglishName;
            LtrUserPassword.Text = user.Password;
        }

        #endregion
    }
}