using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Series.ViewModel;
using Series.ViewModel.Base;
using Series.Views;
using Xamarin.Forms;

namespace Series.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _mappings;
        protected Application CurrentApplication { get { return Application.Current; } }

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
            CreateViewModelMappings();
        }


        private void CreateViewModelMappings()
        {
            _mappings.Add(typeof(MainViewModel), typeof(MainView));
            _mappings.Add(typeof(DetailViewModel), typeof(DetailView));
        }

        public async Task Initialize()
        {
            await NavigateToAsync<MainViewModel>();
        }

        private Task NavigateToAsync<T>()
        {
            throw new NotImplementedException();
        }

        public Task NavigationAsync<TViewModel>() where TViewModel : ViewModelBase => InternalNavigateToAsync(typeof(TViewModel), null);




        public Task NavigationAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase => InternalNavigateToAsync(typeof(TViewModel), parameter);




        public Task NavigationAsync(Type viewModelType) => InternalNavigateToAsync(viewModelType, null);
       
        public Task NavigationAsync(Type viewModelType, object parameter) => InternalNavigateToAsync(viewModelType, parameter);




        public async Task NavigationAsync()
        {
            
        }

        public async Task NavigationBackAsync()
        {
            if(CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBingPage(viewModelType, parameter);
            var navegationPage = CurrentApplication.MainPage as NavigationPage;
            if (navegationPage != null)
            {
                await navegationPage.PushAsync(page);
            }
            else
            {
                CurrentApplication.MainPage = new NavigationPage(page);
            }
        }

         Page CreateAndBingPage(Type viewModelType, object parameter)
        {
            Type pageType = getPageTypeForViewModel(viewModelType);

            if(pageType == null)
            {
                throw new Exception($"O mapeamento para o tipo (viewModelType) não existe");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = ViewModelLocator.Instance.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;
            return page;

        }

        Type getPageTypeForViewModel(Type viewModelType)
        {
            if(!_mappings.ContainsKey(viewModelType))
            {
                throw new Exception($"O tipo (viewModelType) não corresponde a nenhuma view");
            }

            return _mappings[viewModelType];
        }

        public Task RemoveLastFromBackStack()
        {
            throw new NotImplementedException();
        }
        

        public async Task NavigateAndClearBackStackAsync<TViewModel>(object parameter=null) where TViewModel : ViewModelBase
        {
            Page page = CreateAndBingPage(typeof(TViewModel), parameter);
            var navigationPage = CurrentApplication.MainPage as NavigationPage;
            await navigationPage.PushAsync(page);
            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);

            if(navigationPage != null && navigationPage.Navigation.NavigationStack.Count > 0)
            {
                var existingPages = navigationPage.Navigation.NavigationStack.ToList();
                foreach(var existingPage in existingPages)
                {
                    if (existingPage != page) navigationPage.Navigation.RemovePage(existingPage);
                }
            }
        }
    }
}
