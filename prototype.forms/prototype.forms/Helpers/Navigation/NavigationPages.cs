using prototype.forms.Interfaces.Navigation;
using prototype.forms.Models.Navigation.Enums;
using prototype.forms.Views.ActivityIndicator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace prototype.forms.Helpers.Navigation
{
    public class NavigationPages : INavigationPages
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        public void SetMainPage(Pages page) => SetMasterPage(new NavigationPage(new Views.MainPage(page)));

        public async Task ShowLoadingIndicator(string message)
        {
            await _semaphore.WaitAsync();

            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ActivityIndicatorPage());
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private void SetMasterPage(Page page)
        {
            Application.Current.MainPage = page;
        }

        private async Task PushPageAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page, false);
        }
    }
}
