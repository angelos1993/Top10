using System;
using System.Web.UI;
using Top10.BLL;

namespace Top10
{
    public partial class Angelos : Page
    {
        #region Properties

        private UserManager _userManager;
        private UserManager UserManager => _userManager ?? (_userManager = new UserManager());

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnGeneratePasswordsForAllUsers_OnClick(object sender, EventArgs e)
        {
            UserManager.GeneratePasswordsForAllUsers();
        }

        #endregion

        #region Methods

        #endregion
    }
}