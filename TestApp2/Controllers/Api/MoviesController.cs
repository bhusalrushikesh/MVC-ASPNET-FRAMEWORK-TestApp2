using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using TestApp2.Models;

namespace TestApp2.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        //GET /api/movies/1

        public Movie GetMovieById(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return movieInDb;
        }


        //POST /api/movies

        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }

        //PUT /api/movies/1

        [HttpPut]

        public void UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            movieInDb.Name = movie.Name;
            movieInDb.GenreTypeId = movie.GenreTypeId;
            movieInDb.DateAdded = movie.DateAdded;
            movieInDb.RealeaseDate = movie.RealeaseDate;
            movieInDb.NoInStock = movie.NoInStock;

            _context.SaveChanges();

        }


        //DELETE api/movies/1

        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
