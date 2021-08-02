using System;
using System.Collections.Generic;
using System.Text;

namespace prototype.forms.Helpers.Session
{
    public static class SessionHelper
    {
        #region Properties
        private static bool isLoggedIn;
        public static bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set { isLoggedIn = value; }
        }

        #endregion
    }
}
