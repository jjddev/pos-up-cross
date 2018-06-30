using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Series.Services;
using Series.Services.Navigation;

namespace Series.ViewModel.Base
{
    public abstract class ViewModelBase : BindableObject
    {

        protected readonly INavigationService NavigationService;

        string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        public ViewModelBase(string title)
        {


            Title = title;

            NavigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object nagavigationData)
        {
            return Task.FromResult(true);
        }
    }
}
