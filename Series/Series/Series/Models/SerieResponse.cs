using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Series.Models
{
    public class SerieResponse
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("total_results")]
        public long TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("results")]
        public IEnumerable<Serie> Series { get; set; }
    }
}
