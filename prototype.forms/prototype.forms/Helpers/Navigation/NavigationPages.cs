using prototype.forms.Interfaces.Navigation;
using prototype.forms.Models.Navigation.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace prototype.forms.Helpers.Navigation
{
    public class NavigationPages : INavigationPages
    {
        public void SetMainPage(Pages page) => SetMasterPage(new NavigationPage(new Views.MainPage(page)));

        private void SetMasterPage(Page page)
        {
            Application.Current.MainPage = page;
        }
    }
}
