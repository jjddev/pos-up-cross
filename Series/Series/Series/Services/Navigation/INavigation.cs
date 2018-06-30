using Series.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Series.Services.Navigation
{
    public interface INavigation
    {
        Task Initialize();
        Task NavigationAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigationAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        Task NavigationAsync(Type viewModelType);
        Task NavigationAsync(Type viewModelType, object parameter);
        Task NavigationAsync();
        Task NavigateAndClearBackStackAsync<TViewModel>(object parameter = null)  where  TViewModel : ViewModelBase;

        Task RemoveLastFromBackStack();

    }
}
