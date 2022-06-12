using Microsoft.AspNetCore.Mvc;
using SharpBuster.Models;
using SharpBuster.Data;

namespace SharpBuster.Controllers
{
    public class MovieController : Controller
    {
        //dependency injection
        private readonly Data.MyDbContext _db;

        public MovieController(MyDbContext db)
        {
            _db = db;
        }
        //GET
        public IActionResult Index()
        {
            IEnumerable<Movie> objMovieList = _db.Movies;
            return View(objMovieList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie obj)
        {
            _db.Movies.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Entry created successfully";
            return RedirectToAction("Index");
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var movieFromDb = _db.Movies.Find(id);

            if (movieFromDb == null)
                return NotFound();

            return View(movieFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie obj)
        {
            _db.Movies.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Entry editted successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var movieFromDb = _db.Movies.Find(id);

            if (movieFromDb == null)
                return NotFound();

            return View(movieFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var movie = _db.Movies.Find(id);
            if (movie == null)
                return NotFound();

            _db.Movies.Remove(movie);
            TempData["success"] = "Entry deleted successfully";

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Random()
        {
            return View();
        }
        
        //attribute routes
        [Routes("movies/release/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult Release(int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}
