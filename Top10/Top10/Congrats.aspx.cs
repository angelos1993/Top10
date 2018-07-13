using System;
using System.Web.UI;
using Top10.BLL;

namespace Top10
{
    public partial class Congrats : Page
    {
        private int UserId => int.TryParse(Request.QueryString["uid"], out int userId) ? userId : 0;

        private DateTime? Date => new DateTime(int.Parse(Request.QueryString["dt"].Substring(0, 4)),
            int.Parse(Request.QueryString["dt"].Substring(4, 2)),
            int.Parse(Request.QueryString["dt"].Substring(6, 2)));

        private UserManager _userManager;
        private UserManager UserManager => _userManager ?? (_userManager = new UserManager());

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserManager.GetUserByUserId(UserId);
            var dateString = Date?.ToString("dd / MM / yyyy") ?? string.Empty;
            var x = user.IsMale == false ? "ت" : string.Empty;
            LtrTxt.Text = LtrTitle.Text =
                $@"لقد حصل{x} {user.ArabicName} علي الدرجة النهائية في أسئلة اليوم {dateString}";
        }
    }
}