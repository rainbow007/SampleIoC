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

        public async Task<MovieResponse> GetMovie(int id)
        {
            var existingMovie = await _movieRepository.FindByIdAsync(id);

            if (existingMovie == null)
                return new MovieResponse("Movie not found.");

            return new MovieResponse(existingMovie);
        }

        public async Task<MovieResponse> SaveAsync(Movie movie)
        {
            try
            {
                await _movieRepository.AddAsync(movie);
                await _unitOfWork.CompleteAsync();
                
                return new MovieResponse(movie);
            }
            catch (Exception ex)
            {
                return new MovieResponse($"An error occurred when saving the movie: {ex.Message}");
            }
        }

        public async Task<MovieResponse> UpdateAsync(int id, Movie movie)
        {
            var existingMovie = await _movieRepository.FindByIdAsync(id);

            if (existingMovie == null)
                return new MovieResponse("Movie not found.");

            existingMovie.Title = movie.Title;

            try
            {
                _movieRepository.Update(existingMovie);   
                await _unitOfWork.CompleteAsync();
                
                return new MovieResponse(existingMovie);
            }
            catch (Exception ex)
            {
                return new MovieResponse($"An error occurred when updating the movie: {ex.Message}");
            }
        }

        public async Task<MovieResponse> DeleteAsync(int id)
        {
            var existingMovie = await _movieRepository.FindByIdAsync(id);

            if (existingMovie == null)
                return new MovieResponse("Category not found.");

            try
            {
                _movieRepository.Remove(existingMovie);
                await _unitOfWork.CompleteAsync();

                return new MovieResponse(existingMovie);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MovieResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}
