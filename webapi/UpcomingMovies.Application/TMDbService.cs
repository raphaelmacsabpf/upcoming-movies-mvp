using System;
using System.Collections.Generic;
using System.Text;
using UpcomingMovies.Domain.Interfaces;
using UpcomingMovies.Domain.Models;

namespace UpcomingMovies.Application
{
    public class TMDbService : ITMDbService
    {
        private readonly ITMDbRepository _tmdbRepository;

        public TMDbService(ITMDbRepository tmdbRepository)
        {
            _tmdbRepository = tmdbRepository;
        }

        public UpcomingMoviesModel GetUpcomingMovies(int page)
        {
            var upcomingMovies = _tmdbRepository.ListUpcomingMovies(page);

            return upcomingMovies;
        }
    }
}
