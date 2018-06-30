using AwesomeSeries.Models;
using Series.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Series.ViewModel
{
    public class DetailViewModel : ViewModelBase
    {
        //name, overview, poster, backdrop, votes, first

        string _name;

        public string Name {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        string _overview;

        public string Overview
        {
            get { return _overview; }
            set { _overview = value; OnPropertyChanged(); }
        }

        string _poster;
        public string Poster
        {
            get { return _poster; }
            set { _poster = value; OnPropertyChanged(); }
        }


        string _backdrop;
        public string Backdrop
        {
            get { return _backdrop; }
            set { _backdrop = value; OnPropertyChanged(); }
        }

        double _votes;
        public double Votes
        {
            get { return _votes; }
            set { _votes = value; OnPropertyChanged(); }
        }


        string _releaseDate;
        public string ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; OnPropertyChanged(); }
        }

        public DetailViewModel() : base("teste")
        {

        }

        public override async Task InitializeAsync(object parameter)
        {
            var serie = (parameter as Serie);
            Name = serie.Name;
            Title = serie.OriginalName;
            Overview = serie.Overview;
            Poster = serie.PosterPath;
            Backdrop = serie.BackdropPath;
            Votes = serie.VoteAverage;
            ReleaseDate = serie.releaseDate;

            await base.InitializeAsync(parameter);


        }
    
    }
}
