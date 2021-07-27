using prototype.forms.Interfaces.Navigation;

using System;
using System.Collections.Generic;
using System.Text;

namespace prototype.forms.ViewModels.LogIn
{
    public class LogInPageViewModel : BaseViewModel
    {
        #region Properties

        private readonly INavigationPages navigationPages;

        #endregion

        #region Constructor

        public LogInPageViewModel(INavigationPages navigationPages)
        {
            this.navigationPages = navigationPages;
        }

        #endregion
    }
}
