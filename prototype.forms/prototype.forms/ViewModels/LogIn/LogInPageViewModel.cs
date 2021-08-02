using prototype.forms.Helpers.Command;
using prototype.forms.Helpers.Session;
using prototype.forms.Interfaces.Navigation;

using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Input;

using Xamarin.Forms;

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

        #region Commands
        private ICommand logInCommand;
        public ICommand LogInCommand => logInCommand ?? (logInCommand = new Command(() =>
        {
            /** Log in User */
            SessionHelper.IsLoggedIn = true;
            navigationPages.SetMainPage(Models.Navigation.Enums.Pages.HomePage);
        }));
        #endregion
    }
}
