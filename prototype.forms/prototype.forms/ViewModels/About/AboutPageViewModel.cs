﻿using prototype.forms.Interfaces.Navigation;

using System;
using System.Collections.Generic;
using System.Text;

namespace prototype.forms.ViewModels.About
{
    public class AboutPageViewModel : BaseViewModel
    {
        #region Properties

        private readonly INavigationPages navigationPages;

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        #endregion

        #region Constructor

        public AboutPageViewModel(INavigationPages navigationPages)
        {
            this.navigationPages = navigationPages;

            Description = "Put Description here...";
        }

        #endregion
    }
}
