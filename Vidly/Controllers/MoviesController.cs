using System;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Index()
        {
            return View(new Movie().GetMovies());
        }

        [Route(@"movies/released/{year}/{month:regex(\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            return Content($"Year: {year}, Month: {month}");
        }

    }

    public class Person
    {
        public int Id { get; set; } = 10;
        public string Name { get; set; } = "Jon Doe";
        public DateTime Dob { get; set; } = DateTime.Now.AddYears(-18);
    }
}
