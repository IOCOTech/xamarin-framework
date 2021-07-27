using Autofac;

using prototype.forms.ViewModels.Splash;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prototype.forms.Views.Splash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreenPage : ContentPage
    {
        public SplashScreenPage()
        {
            InitializeComponent();
            BindingContext = App.container.Resolve<SplashScreenPageViewModel>();
        }
    }
}