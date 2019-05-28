using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpcomingMovies.Api.ViewModels
{
    public class UpcomingMoviesViewModel
    {
        public List<ResultViewModel> results { get; set; }
        public int page { get; set; }
        public int total_pages { get; set; }
    }
}
