using prototype.forms.Interfaces.Navigation;

using System;
using System.Collections.Generic;
using System.Text;

namespace prototype.forms.ViewModels.About
{
    public class AboutPageViewModel : BaseViewModel
    {
        #region Properties

        private readonly INavigationPages navigationPages;

        #endregion

        #region Constructor

        public AboutPageViewModel(INavigationPages navigationPages)
        {
            this.navigationPages = navigationPages;
        }

        #endregion
    }
}
