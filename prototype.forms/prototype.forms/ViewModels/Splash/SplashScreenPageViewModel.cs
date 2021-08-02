using prototype.forms.Interfaces.Navigation;
using prototype.forms.Models.Navigation.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace prototype.forms.ViewModels.Splash
{
    public class SplashScreenPageViewModel : BaseViewModel
    {
        #region Properties

        private readonly INavigationPages navigationPages;

        #endregion

        #region Constructor

        public SplashScreenPageViewModel(INavigationPages navigationPages)
        {
            this.navigationPages = navigationPages;

            /** Load initial data => Replace with API call */
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    navigationPages.SetMainPage(Pages.LoginPage);
                });

                return false;
            });
        }

        #endregion
    }
}
