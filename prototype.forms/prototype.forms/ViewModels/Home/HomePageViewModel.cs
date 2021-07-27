﻿using prototype.forms.Interfaces.Navigation;

using System;
using System.Collections.Generic;
using System.Text;

namespace prototype.forms.ViewModels.Home
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Properties

        private readonly INavigationPages navigationPages;

        #endregion

        #region Constructor

        public HomePageViewModel(INavigationPages navigationPages)
        {
            this.navigationPages = navigationPages;
        }

        #endregion
    }
}
