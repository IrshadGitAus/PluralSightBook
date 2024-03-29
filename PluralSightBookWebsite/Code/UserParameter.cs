﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace PluralSightBook.Code
{
    public class UserParameter:Parameter
    {
        protected override object Evaluate(HttpContext context, System.Web.UI.Control control)
        {
            var currentUser = Membership.GetUser();
            this.DbType = System.Data.DbType.Guid;
            return currentUser.ProviderUserKey;
        }
    }
}