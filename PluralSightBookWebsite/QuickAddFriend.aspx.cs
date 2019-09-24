using PluralSightBook.Code;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using PluralSightBook.Core.Services;
using PluralSightBook.Infrastructure.Data;
using PluralSightBook.Infrastructure.Services;

namespace PluralSightBook
{
    public partial class QuickAddFriend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string currentUserEmail = Membership.GetUser().Email;
            string currentUserName = MyProfile.CurrentUser.Name;
            string friendEmail = Request.QueryString["email"];
            Guid currentUserId = (Guid)Membership.GetUser().ProviderUserKey;

            //var friendsService = new FriendsService();
            var friendsService = new FriendsService(new EfFriendRepository(), new NotificationService(new EfQueryUsersByEmail(), new DebugEmailSender()));

            friendsService.AddFriend(currentUserId, currentUserEmail, currentUserName, friendEmail);

            SuccessLabel.Text = "Added Friend: " + friendEmail;
        }
    }
}