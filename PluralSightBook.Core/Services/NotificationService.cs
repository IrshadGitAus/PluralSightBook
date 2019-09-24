using PluralSightBook.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluralSightBook.Core.Services
{
    public class NotificationService : PluralSightBook.Core.Interfaces.INotificationService
    {
        private readonly IQueryUsersByEmail _queryUsersByEmail;
        private readonly ISendEmail _sendmail;
        public NotificationService(IQueryUsersByEmail queryUsersByEmail, ISendEmail sendmail)
        {
            _queryUsersByEmail = queryUsersByEmail;
            _sendmail = sendmail;
        }
        public void SendNotification(string currentUserEmail, string currentUserName, string friendEmail)
        {
            string emailBody = "";

            bool isFriendMember = _queryUsersByEmail.UserWithEmailExists(friendEmail);

            if (isFriendMember)
            {
                //This user is already a member. Now check if he is already your friend

                //var friendUserId = (Guid)Membership.GetUser(Membership.GetUserNameByEmail(friendEmail)).ProviderUserKey;

                var friendUserId = _queryUsersByEmail.GetUserByEmail(friendEmail).UserId;

                //bool currentUserAlreadyFriend = context.Friends.Any(f => f.UserId == friendUserId && f.EmailAddress == currentUserEmail);
                bool currentUserAlreadyFriend = _queryUsersByEmail.IsUserWithEmailFriendOfUser(friendUserId, currentUserEmail);

                if (currentUserAlreadyFriend)
                {
                    //I am already in the friend list of "EmailTextBox.Text". So, you add him as a friend and let your friend know that you too have added him as your friend

                    emailBody = String.Format(@"Good News! Your friend {0} just added you as a friend", currentUserEmail);

                }
                else
                {
                    //I am not added as a friend in the friend list of "EmailTextBox.Text". So ask him to add me as a friend

                    emailBody = String.Format(@"{0} added you as a friend. Click here to add them as your friend:http://localhost:4927/QuickAddFriend.aspx?email={1}", currentUserName, currentUserEmail);

                }

            }
            else
            {
                //This user is not a member
                emailBody = String.Format(@"{0} added you as a friend. Click here to register your own account and then add them as your friend:http://localhost:4927/QuickAddFriend.aspx?email={1}", currentUserName, currentUserEmail);
            }

            //Debug.Print("Sending Email: " + emailBody);
            _sendmail.SendEmail(emailBody);
        }
    }
}
