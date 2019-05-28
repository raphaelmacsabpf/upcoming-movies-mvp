using System;
using System.Collections.Generic;
using System.Text;
using UpcomingMovies.Domain.Models;

namespace UpcomingMovies.Domain.Interfaces
{
    public interface ITMDbService
    {
        UpcomingMoviesModel GetUpcomingMovies(int page);
    }
}
