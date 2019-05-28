using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.Infrastructure.TMDbApi
{
    public class UpcomingMoviesDto
    {
        public List<ResultDto> results { get; set; }
        public int page { get; set; }
        public int total_results { get; set; }
        public DatesDto dates { get; set; }
        public int total_pages { get; set; }
    }
}
