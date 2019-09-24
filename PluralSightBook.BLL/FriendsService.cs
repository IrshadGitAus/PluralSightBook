using PluralSightBook.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PluralSightBook.BLL
{
    public class FriendsService
    {
        public void AddFriend(Guid currentUserId,string currentUserEmail, string currentUserName, string friendEmail)
        {
            var context = new aspnetdbEntities();

            var newFriend = context.Friends.CreateObject();
            newFriend.UserId = currentUserId;
            newFriend.EmailAddress = friendEmail;

            context.AddToFriends(newFriend);

            context.SaveChanges();


            /*var context = new Code.aspnetdbEntities();
            var newFriend=context.Friends.CreateObject();
            newFriend.UserId = (Guid)Membership.GetUser().ProviderUserKey;
            newFriend.EmailAddress = EmailTextBox.Text;
            context.Friends.AddObject(newFriend);
            context.SaveChanges();
                 */

            var notificationService = new NotificationService();
            notificationService.SendNotification(currentUserEmail, currentUserName, friendEmail, context);
        }

        

    }
}
