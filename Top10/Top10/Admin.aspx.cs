using System;
using System.Web.UI;
using Top10.BLL;

namespace Top10
{
    public partial class Admin : Page
    {
        #region Properties

        private UserManager _userManager;
        private UserManager UserManager => _userManager ?? (_userManager = new UserManager());

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
            }
        }

        #endregion

        #region Methods

        private void PageLoad()
        {
            //TODO: check if session is null or the user is not admin, then go to the Index.aspx
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