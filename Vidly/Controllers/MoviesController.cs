using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _db  = ApplicationDbContext.Create();

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
        }

        public ActionResult Index()=> View(_db.Movies.Include(m => m.Genre).ToList());

        public ActionResult Edit(int? id, MovieViewModel movieViewModel)
        {
            if (movieViewModel.Movie == null && movieViewModel.Genres == null)
            {
                movieViewModel = new MovieViewModel()
                {
                    Movie = _db.Movies.SingleOrDefault(m => m.Id == id),
                    Genres = _db.Genres.ToList(),
                };

            }
            return View(movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieViewModel movieViewModel)
        {
            if (!ModelState.IsValid)
            {
                movieViewModel.Genres = _db.Genres.ToList();
                return View("Edit", movieViewModel);
            }
            if (movieViewModel.Movie.Id == 0)
            {
                _db.Movies.Add(movieViewModel.Movie);
            }
            else
            {
                var oldMovie = _db.Movies.Single(m => m.Id == movieViewModel.Movie.Id);
                oldMovie.Name = movieViewModel.Movie.Name;
                oldMovie.ReleaseDate = movieViewModel.Movie.ReleaseDate;
                oldMovie.DateAdded = movieViewModel.Movie.DateAdded;
                oldMovie.GenreId = movieViewModel.Movie.GenreId;
                oldMovie.InStock = movieViewModel.Movie.InStock;
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _db.Movies.Remove(_db.Movies.Single(m => m.Id == id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route(@"movies/released/{year}/{month:regex(\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int? year, int? month) => Content($"Year: {year}, Month: {month}");

    }

}
