using Autofac;
using prototype.forms.Helpers.Navigation;
using prototype.forms.Interfaces.Navigation;
using prototype.forms.Services;
using prototype.forms.Views;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace prototype.forms
{
    public partial class App : Application
    {
        #region Properties

        public static IContainer container;
        private static readonly ContainerBuilder builder = new ContainerBuilder();

        #endregion

        #region Constructor

        public App()
        {
            InitializeComponent();
            SetUpIOC();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new Views.Splash.SplashScreenPage());

            /** Leaving this here for future use when the Xamarin team implements the passing of complex
             * data objects between pages using URI based navigation introduced by the Shell */
           //MainPage = new AppShell();
        }

        #endregion

        #region Methods

        private void SetUpIOC()
        {
            /** Add other items for IOC in here */

            builder.RegisterType<NavigationPages>().As<INavigationPages>().SingleInstance();
            builder.RegisterType<MenuPage>().AsSelf().AsImplementedInterfaces();

            RegisterAllViewModels();

            if (container == null)
                container = builder.Build();
        }

        private void RegisterAllViewModels()
        {
            GetType().Assembly.GetTypes()
                     .Where(type => type.IsClass)
                     .Where(type => type.Name.EndsWith("ViewModel"))
                     .ForEach(viewModelType => builder.RegisterType(viewModelType).AsSelf().AsImplementedInterfaces());
        }

        protected override void OnStart()
        {
            /** Place code to be executed when app starts in here */
        }

        protected override void OnSleep()
        {
            /** Place code to be executed when app goes to sleep (goes to the background) in here */
        }

        protected override void OnResume()
        {
            /** Place code to be executed when app awakes (returns from the background) in here */
        }

        #endregion
    }
}
