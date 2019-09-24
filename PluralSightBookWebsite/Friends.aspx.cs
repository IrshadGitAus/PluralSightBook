using PluralSightBook.Core.Services;
using PluralSightBook.Infrastructure.Data;
using PluralSightBook.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PluralSightBook
{
    public partial class Friends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGridView();
            }

        }

        private void BindGridView()
        {
            Guid currentUserId = (Guid) Membership.GetUser().ProviderUserKey;

            var friendsService = new FriendsService(new EfFriendRepository(), new NotificationService(new EfQueryUsersByEmail(), new DebugEmailSender()));

            GridView1.DataSource=friendsService.ListFriendsOf(currentUserId);
            GridView1.DataBind();

        }

        protected void Delete_LinkButton_Click(object sender, EventArgs e)
        {
            var friendId = Convert.ToInt32(((LinkButton)sender).CommandArgument);

            var friendsService = new FriendsService(new EfFriendRepository(), new NotificationService(new EfQueryUsersByEmail(), new DebugEmailSender()));

            friendsService.DeleteFriend(friendId);
            BindGridView();
        }

    }
}