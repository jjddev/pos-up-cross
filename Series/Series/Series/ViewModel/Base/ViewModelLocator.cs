using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Autofac;
using AwesomeSeries.Infra.HttpTools;
using Refit;
using Series.Infra;
using Series.Infra.Api;
using Series.Services;
using Series.Services.Navigation;

namespace Series.ViewModel.Base
{
    public class ViewModelLocator
    {
        IContainer _container;
        ContainerBuilder _containerBuilder;

        static readonly ViewModelLocator _instance = new ViewModelLocator();
        public static ViewModelLocator Instance
        {
            get { return _instance; }
        }

        public ViewModelLocator()
        {
            _containerBuilder = new ContainerBuilder();

            _containerBuilder.RegisterType<NavigationService>().As<INavigationService>();
            _containerBuilder.RegisterType<SerieService>().As<ISerieService>();

            _containerBuilder.RegisterType<MainViewModel>();
            _containerBuilder.RegisterType<DetailViewModel>();

            _containerBuilder.Register(api =>
            {
                var client = new HttpClient(new HttpLoggingHandler())
                {
                    BaseAddress = new Uri(AppSettings.ApiUrl),
                    Timeout = TimeSpan.FromSeconds(90)
                };

                Console.WriteLine("AQUI>>>");
                return RestService.For<ITmdbApi>(client);

            }).As<ITmdbApi>().InstancePerDependency();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public void Register<TInterface, TImplementation>()
            where TImplementation : TInterface
        {
            _containerBuilder.RegisterType<TImplementation>().As<TInterface>();
        }

        public void Register<T>() where T : class
        {
            _containerBuilder.RegisterType<T>();
        }

        public void Build()
        {
            if (_container == null)
                _container = _containerBuilder.Build();
        }
    }
}
