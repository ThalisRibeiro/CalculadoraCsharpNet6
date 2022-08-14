using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCalc
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<ViewModels.Services.IMessage, Views.Services.Message>();
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
