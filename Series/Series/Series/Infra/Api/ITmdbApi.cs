using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
using Series.Models;

namespace Series.Infra.Api
{
    [Headers("Content-Type: application/json")]
    public interface ITmdbApi
    {
        [Get("/tv/popular?api_key={apiKey}")]
        Task<SerieResponse> GetSerieResponseAsync(string apiKey);
    }
}
