using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UpcomingMovies.Api.ViewModels;
using UpcomingMovies.Application;
using UpcomingMovies.Domain.Interfaces;
using UpcomingMovies.Domain.Models;

namespace UpcomingMovies.Api.Controllers
{
    [Route("api/[controller]")]
    public class UpcomingMoviesController : Controller
    {
        private readonly ITMDbService _tmdbService;
        private readonly Mapper _autoMapper;

        public UpcomingMoviesController(ITMDbService tmdbService)
        {
            _autoMapper = SetupAutoMapper();

            _tmdbService = tmdbService;
        }

        // GET api/upcomingmovies/1
        [HttpGet("{page}")]
        public ObjectResult Get(int page)
        {
            var upcomingMoviesModel =_tmdbService.GetUpcomingMovies(page);
            var upcomingMoviesViewModel = _autoMapper.DefaultContext.Mapper.Map<UpcomingMoviesModel, UpcomingMoviesViewModel>(upcomingMoviesModel);

            return Ok(upcomingMoviesModel);
        }

        private Mapper SetupAutoMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<ResultModel, ResultViewModel>()
                    .ForMember(viewModel => viewModel.genres, cfg => cfg.Ignore())
                    .ForMember(viewModel => viewModel.backdrop_path, cfg => cfg.MapFrom(model => model.BackdropPath))
                    .ForMember(viewModel => viewModel.poster_path, cfg => cfg.MapFrom(model => model.PosterPath))
                    .ForMember(viewModel => viewModel.release_date, cfg => cfg.MapFrom(model => model.ReleaseDate))
                    .AfterMap((model, viewModel) =>
                    {
                        viewModel.genres = model.Genres.Select(g => g.Name).ToList();
                    });
                configuration.CreateMap<UpcomingMoviesModel, UpcomingMoviesViewModel>()
                    .ForMember(viewModel => viewModel.total_pages, cfg => cfg.MapFrom(model => model.TotalPages));
            });

            var mapper = new Mapper(mapperConfiguration);
            return mapper;
        }
    }
}
