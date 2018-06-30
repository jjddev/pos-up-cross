using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AwesomeSeries.Models;
using Refit;

namespace Series.Infra.Api
{
    [Headers("Content-Type: application/json")]
    public interface ITmdbApi
    {
        [Get("/tv/popluar?api_key={apiKey}")]
        Task<SerieResponse> GetSerieResponseAsync(string apiKey);

    }
}
