using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpcomingMovies.Api.ViewModels
{
    public class ResultViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string poster_path { get; set; }
        public List<string> genres { get; set; }
        public string backdrop_path { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
    }
}
