using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.IoC.Domain.Entities;
using Sample.IoC.Domain.Interfaces;
using AutoMapper;
using Sample.IoC.Resources;
using Sample.IoC.Extensions;

namespace Sample.IoC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<IEnumerable<MovieResource>> GetAllAsync()
        {
            var movies = await _movieService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieResource>>(movies);
            
            return resources;
        }
        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovie(int id)
        {
            var result = await _movieService.GetMovie(id);

            if (!result.Success)
              return BadRequest(result);

            return Ok(result);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, [FromBody] SaveMovieResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var movie = _mapper.Map<SaveMovieResource, Movie>(resource);
            var result = await _movieService.UpdateAsync(id, movie);

            if (!result.Success)
                return BadRequest(result);

            // var movieResource = _mapper.Map<Movie, MovieResource>(result.Movie);
            return Ok(result);
        }
           
        // POST: api/Movies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostMovie([FromBody] SaveMovieResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var movie = _mapper.Map<SaveMovieResource, Movie>(resource);

            var result = await _movieService.SaveAsync(movie);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result);

           //  var movieResource = _mapper.Map<Movie, MovieResource>(result.Movie);
            return Ok(result);
        }

    }
}
