using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TestApp2.Models;
using TestApp2.ViewModels;

namespace TestApp2.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Intersteller!"
            };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        /*public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }*/
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genreType = _context.GenreTypes.ToList();

            var viewModel = new NewMovieViewModel
            {
                Movie = new Movie(),
                GenreTypes = genreType
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movies == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel
            {
                Movie = movies,
                GenreTypes = _context.GenreTypes
            };

            return View("New", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    GenreTypes = _context.GenreTypes
                };
                return View("New", viewModel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.RealeaseDate = movie.RealeaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                movieInDb.NoInStock = movie.NoInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.GenreType).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View(movies);
            }

            return View("ReadOnlyList", movies);
        }



        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(m => m.GenreType).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }



        public ActionResult Delete(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDB == null)
            {
                return HttpNotFound();
            }

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}