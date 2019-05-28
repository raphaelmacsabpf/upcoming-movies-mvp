using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.Domain.Models
{
    public class ResultModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterPath { get; set; }
        public List<GenreModel> Genres { get; set; }
        public string BackdropPath { get; set; }
        public string overview { get; set; }
        public string ReleaseDate { get; set; }
    }
}