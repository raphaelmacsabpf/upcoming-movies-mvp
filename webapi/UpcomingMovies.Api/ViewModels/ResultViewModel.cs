using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpcomingMovies.Api.ViewModels
{
    public class ResultViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterPath { get; set; }
        public List<string> Genres { get; set; }
        public string BackdropPath { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }
    }
}
