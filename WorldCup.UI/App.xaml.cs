using Autofac;
using System;
using System.Net.Http;
using System.Windows;
using WorldCup.Data.Repository;
using WorldCup.UI.ViewModels;
using WorldCup.UI.Views;

namespace WorldCup.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            _container = BuildContainer();

            MainWindow = new MainView();
            MainWindow.DataContext = _container.Resolve<MainViewModel>();
            MainWindow.Show();
        }

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WorldCupRepository>().As<IWorldCupRepository>().SingleInstance();
            builder.RegisterType<MainViewModel>();
            builder.Register(c =>
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52757");
                return client;
            })
            .SingleInstance();

            return builder.Build();
        }
    }
}
