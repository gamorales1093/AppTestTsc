using AppTestTsc.ViewModels;
using AppTestTsc.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppTestTsc
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private  void OnMenuItemClicked(object sender, EventArgs e)
        {
             App.Current.MainPage = new LoginwithSocialIconPage();
        }
    }
}
