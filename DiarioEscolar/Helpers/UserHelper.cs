using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DiarioEscolar.Helpers
{
    public static class UserHelper
    {
        public static string CurrentProviderUserKey()
        {
            return Membership.GetUser().ProviderUserKey.ToString();
        }

    }
}