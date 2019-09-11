using PluralSightBookWebsite.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;


namespace PluralSightBookWebsite
{
    public partial class AddFriend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            var context = new aspnetdbEntities();

            var newFriend = context.Friends.CreateObject();
            newFriend.UserId = (Guid)Membership.GetUser().ProviderUserKey;
            newFriend.EmailAddress = EmailTextBox.Text;

            context.AddToFriends(newFriend);

            context.SaveChanges();

            
        /*var context = new Code.aspnetdbEntities();
        var newFriend=context.Friends.CreateObject();
        newFriend.UserId = (Guid)Membership.GetUser().ProviderUserKey;
        newFriend.EmailAddress = EmailTextBox.Text;
        context.Friends.AddObject(newFriend);
        context.SaveChanges();
             */

            string emailBody="";

            bool isFriendMember = !String.IsNullOrWhiteSpace(Membership.GetUserNameByEmail(EmailTextBox.Text));

            if (isFriendMember)
            {
                //This user is already a member. Now check if he is already your friend

                var friendUserId = (Guid)Membership.GetUser(Membership.GetUserNameByEmail(EmailTextBox.Text)).ProviderUserKey;

                string currentUserEmail = Membership.GetUser().Email;
                bool currentUserAlreadyFriend = context.Friends.Any(f => f.UserId == friendUserId && f.EmailAddress == currentUserEmail);
                
                if (currentUserAlreadyFriend)
                {
                    //I am already in the friend list of "EmailTextBox.Text". So, you add him as a friend and let your friend know that you too have added him as your friend

                    emailBody=String.Format(@"Good News! Your friend {0} just added you as a friend",Membership.GetUser().Email);
                    
                }
                else
                {
                    //I am not added as a friend in the friend list of "EmailTextBox.Text". So ask him to add me as a friend

                    emailBody=String.Format(@"{0} added you as a friend. Click here to add them as your friend:http://localhost:4927/QuickAddFriend.aspx?email={1}" ,MyProfile.CurrentUser.Name,Membership.GetUser().Email);

                }

            }
            else
            {
                //This user is not a member
                emailBody=String.Format(@"{0} added you as a friend. Click here to register your own account and then add them as your friend:http://localhost:4927/QuickAddFriend.aspx?email={1}" ,MyProfile.CurrentUser.Name,Membership.GetUser().Email);
            }

            Debug.Print("Sending Email: " + emailBody);

            Response.Redirect("Friends.aspx");
        }
    }
}