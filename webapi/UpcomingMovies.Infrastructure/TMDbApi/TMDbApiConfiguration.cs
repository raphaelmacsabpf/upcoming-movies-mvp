using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.Infrastructure.TMDbApi
{
    public class TMDbApiConfiguration
    {
        public TMDbApiConfiguration(string apiPath, string apiKey)
        {
            ApiPath = apiPath;
            ApiKey = apiKey;
        }

        public string ApiPath { get; }
        public string ApiKey { get; }
    }
}
