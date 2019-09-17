using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PluralSightBook.Code;

namespace PluralSightBook
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameLiteral.Text = MyProfile.CurrentUser.Name;
            AuthorLiteral.Text = MyProfile.CurrentUser.FavoritePluralsightAuthor;
        }
    }
}