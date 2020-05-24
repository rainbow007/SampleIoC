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
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

            */
           
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
                return BadRequest(result.Message);

            var movieResource = _mapper.Map<Movie, MovieResource>(result.Movie);
            return Ok(movieResource);

            //await _movieService.PostMovie(movie);
            //return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        /*

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        */

        bool MovieExists(int id)
        {
            return _movieService.MovieExists(id);
        }
    }
}
