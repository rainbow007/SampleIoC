using Sample.IoC.Domain.Entities;

namespace Sample.IoC.Domain.Services.Communication
{
    public class SaveMovieResponse : BaseResponse
    {
        public Movie Movie { get; private set; }

        private SaveMovieResponse(bool success, string message, Movie movie) : base(success, message)
        {
            Movie = movie;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="movie">Saved movie.</param>
        /// <returns>Response.</returns>
        public SaveMovieResponse(Movie movie) : this(true, string.Empty, movie)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveMovieResponse(string message) : this(false, message, null)
        { }
    }
}
