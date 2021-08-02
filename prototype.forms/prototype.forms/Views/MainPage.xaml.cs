using Autofac;

using prototype.forms.Models.Navigation.Enums;
using prototype.forms.Views.About;
using prototype.forms.Views.Home;
using prototype.forms.Views.LogIn;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prototype.forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage(Pages page)
        {
            InitializeComponent();

            // Set master to menu page
            if (Master == null)
                Master = App.container.Resolve<MenuPage>();

            MasterBehavior = MasterBehavior.Popover;

            switch (page)
            {
                case Pages.LoginPage:
                    Detail = new NavigationPage(new LogInPage());
                    break;
                case Pages.HomePage:
                    Detail = new NavigationPage(new HomePage());
                    break;
                case Pages.AboutPage:
                    Detail = new NavigationPage(new AboutPage());
                        break;
            }
        }
    }
}