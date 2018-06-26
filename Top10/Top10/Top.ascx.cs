using System;
using System.Linq;
using System.Web.UI;
using Top10.BLL;

namespace Top10
{
    public partial class Top1 : UserControl
    {
        private UserGradeManager _userGradeManager;
        private UserGradeManager UserGradeManager => _userGradeManager ?? (_userGradeManager = new UserGradeManager());
        public bool IsAdmin { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var allUserGrades = UserGradeManager.GeTopUserVms(IsAdmin);
            if (allUserGrades.Any())
            {
                DivTopUsers.Visible = true;
                DivNoTopUsers.Visible = false;
                RepTopUsers.DataSource = allUserGrades;
                RepTopUsers.DataBind();
            }
            else
            {
                DivTopUsers.Visible = false;
                DivNoTopUsers.Visible = true;
            }
        }
    }
}