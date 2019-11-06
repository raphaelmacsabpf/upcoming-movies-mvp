using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using UpcomingMovies.Domain.Interfaces;
using UpcomingMovies.Domain.Models;
using UpcomingMovies.Infrastructure.TMDbApi;

namespace UpcomingMovies.Infrastructure.Repositories
{
    public class TMDbRepository : ITMDbRepository
    {
        private readonly string _apiKey;
        private readonly string _apiPath;
        private readonly HttpClient _httpClient;
        private readonly Mapper _autoMapper;
        private GenresModel _genresModel;

        public TMDbRepository(TMDbApiConfiguration tmdbApiConfiguration)
        {
            _httpClient = new HttpClient();
            _autoMapper = SetupAutoMapper();

            _apiPath = tmdbApiConfiguration.ApiPath;
            _apiKey = tmdbApiConfiguration.ApiKey;

            FetchStaticData();
        }

        public UpcomingMoviesModel ListUpcomingMovies(int page)
        {
            var upcomingResultApiReponse = GetTMDbAPIData($"/movie/upcoming?page={page}&language=en-US");

            var upcomingMoviesDto = JsonConvert.DeserializeObject<UpcomingMoviesDto>(upcomingResultApiReponse);

            var upcomingMoviesModel = _autoMapper.DefaultContext.Mapper.Map<UpcomingMoviesDto, UpcomingMoviesModel>(upcomingMoviesDto);
            return upcomingMoviesModel;
        }

        private string GetTMDbAPIData(string url)
        {
            var apiKeyInUrl = $"&api_key={_apiKey}";
            var fullPath = $"{_apiPath}{url}{apiKeyInUrl}";
            
            var dataFetchedFromApi = _httpClient.GetAsync(fullPath).Result.Content.ReadAsStringAsync().Result;
            return dataFetchedFromApi;
        }

        private Mapper SetupAutoMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<GenreDto, GenreModel>();
                configuration.CreateMap<GenresDto, GenresModel>();
                configuration.CreateMap<ResultDto, ResultModel>()
                    .ForMember(model => model.Genres, cfg => cfg.Ignore())
                    .ForMember(model => model.BackdropPath, cfg => cfg.MapFrom(dto => dto.backdrop_path))
                    .ForMember(model => model.PosterPath, cfg => cfg.MapFrom(dto => dto.poster_path))
                    .ForMember(model => model.ReleaseDate, cfg => cfg.MapFrom(dto => dto.release_date))
                    .AfterMap((dto, model) =>
                    {
                        model.Genres = GetGenresFromGenresId(dto.genre_ids);
                    });
                configuration.CreateMap<UpcomingMoviesDto, UpcomingMoviesModel>()
                    .ForMember(model => model.TotalPages, cfg => cfg.MapFrom(dto => dto.total_pages));
            });

            var mapper = new Mapper(mapperConfiguration);
            return mapper;
        }

        private void FetchStaticData()
        {
            //Genres
            var genresApiResponse = GetTMDbAPIData("/genre/movie/list?language=en-US");
            var genresDto = JsonConvert.DeserializeObject<GenresDto>(genresApiResponse);
            this._genresModel = _autoMapper.DefaultContext.Mapper.Map<GenresDto, GenresModel>(genresDto);
        }

        private List<GenreModel> GetGenresFromGenresId(List<int> genreIds)
        {
            var genres = new List<GenreModel>();

            foreach(var genreId in genreIds)
            {
                var genreModel = new GenreModel()
                {
                    Id = genreId,
                    Name = _genresModel.Genres.First(g => g.Id == genreId).Name
                };

                genres.Add(genreModel);
            }

            return genres;
        }
    }
}
