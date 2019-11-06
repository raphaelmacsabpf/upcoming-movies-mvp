using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.Domain.Models
{
    public class UpcomingMoviesModel
    {
        public List<ResultModel> Results { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}
