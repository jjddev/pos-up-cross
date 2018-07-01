using Series.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Series.Services
{
    public interface ISerieService
    {
        Task<SerieResponse> GetSeriesAsync();
    }
}
