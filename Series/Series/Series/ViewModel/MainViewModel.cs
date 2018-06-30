using AwesomeSeries.Models;
using Series.Services;
using Series.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Series.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        readonly ISerieService _serieService;

        public ICommand ItemClickCommand { get; }

        public ObservableCollection<Serie>Items {get;}

        public MainViewModel(ISerieService serieService) : base("series")
        {
            _serieService = serieService;
            Items = new ObservableCollection<Serie>();

            ItemClickCommand = new Command<Serie>(async (item) => await ItemClickCommandExecute(item));

        }

        async Task ItemClickCommandExecute(Serie serie)
        {
            if(serie != null)
            {
                await NavigationService.NavigationAsync<DetailViewModel>(serie);
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
            await LoadDataAsync();
        }

        async Task LoadDataAsync()
        {
            var result = await _serieService.GetSeriesAsync();
            addItens(result);
        }

        private void addItens(SerieResponse result)
        {
            Items.Clear();
            result?.Series.ToList()?.ForEach(i => Items.Add(i));

            
        }
    }
}
