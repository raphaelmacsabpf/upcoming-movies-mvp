using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpcomingMovies.Api.ViewModels
{
    public class UpcomingMoviesViewModel
    {
        public List<ResultViewModel> Results { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}
