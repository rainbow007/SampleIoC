using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.IoC.Domain.Entities;
using Sample.IoC.Domain.Entities.DTOs;
using Sample.IoC.Domain.Interfaces;
using Sample.IoC.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.IoC.Domain.Services.Communication;

namespace Sample.IoC.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Movie>> ListAsync()
        {
            return await _movieRepository.ListAsync();
        }

        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
           return await _movieRepository.GetMovie(id);
        }

        public async Task<SaveMovieResponse> SaveAsync(Movie movie)
        {
            try
            {
                await _movieRepository.AddAsync(movie);
                await _unitOfWork.CompleteAsync();

                return new SaveMovieResponse(movie);
            }
            catch (Exception ex)
            {
                return new SaveMovieResponse($"An error occurred when saving the movie: {ex.Message}");
            }
        }
        public bool MovieExists(int id)
        {
            return _movieRepository.MovieExists(id);
        }
    }
}
