﻿using prototype.forms.Interfaces.Navigation;
using prototype.forms.Models.Menu;
using prototype.forms.Models.Menu.Enums;
using prototype.forms.Models.Navigation.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace prototype.forms.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        #region Properties

        private readonly INavigationPages navigationPages;

        private ObservableCollection<MenuOption> menuItems;
        public ObservableCollection<MenuOption> MenuItems
        {
            get { return menuItems; }
            set { SetProperty(ref menuItems, value); }
        }

        #endregion

        #region Constructor

        public MenuPageViewModel(INavigationPages navigationPages)
        {
            this.navigationPages = navigationPages;

            BuildMenuItems();
        }

        #endregion

        #region Methods

        private void BuildMenuItems()
        {
            MenuItems = new ObservableCollection<MenuOption>()
            {
                new MenuOption()
                {
                    Type = MenuTypes.About,
                    Title = "About Us"
                },
                new MenuOption()
                {
                    Type = MenuTypes.Home,
                    Title = "Home"
                },
                new MenuOption()
                {
                    Type = MenuTypes.LogIn,
                    Title = "Log In",
                    Activated = true
                }
            };
        }

        private async void Navigate(MenuTypes menuType)
        {
            switch (menuType)
            {
                case MenuTypes.LogIn:
                    navigationPages.SetMainPage(Pages.LoginPage);
                    break;
                case MenuTypes.Home:
                    navigationPages.SetMainPage(Pages.HomePage);
                    break;
                case MenuTypes.About:
                    navigationPages.SetMainPage(Pages.AboutPage);
                    break;
            }
        }

        #endregion

        #region Commands

        private ICommand navigateCommand;
        public ICommand NavigateCommand => navigateCommand ?? (navigateCommand = new Command((menuItem) =>
        {
            var clickedMenuItem = (MenuOption)menuItem;

            if (!clickedMenuItem.Activated)
            {
                clickedMenuItem.Activated = true;

                menuItems.Where(x => x.Type != clickedMenuItem.Type).ToList().ForEach((item) =>
                {
                    item.Activated = false;
                });

                Navigate(clickedMenuItem.Type);
            }
        }));

        #endregion
    }
}