using System;
using Autofac;
using NewsReader.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace NewsReader
{
    public partial class App : Application
    {
        static IContainer container;
        static readonly ContainerBuilder builder = new ContainerBuilder();

        public App()
        {
            InitializeComponent();
            DependencyResolver.ResolveUsing(type => container.IsRegistered(type) ? container.Resolve(type) : null);
            MainPage = new NavigationPage( new NewsItemListPage());
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

        public static void BuildContainer()
        {
            container = builder.Build();
        }

        public static void RegisterType<T>() where T : class
        {
            builder.RegisterType<T>();
        }

        public static void RegisterType<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            builder.RegisterType<T>().As<TInterface>();
        }
    }
}
