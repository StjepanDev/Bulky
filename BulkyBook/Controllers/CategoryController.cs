using BulkyBook.Data;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {

        private readonly BulkyDbContext _db;

        public CategoryController(BulkyDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View( //new Category se salje ali ne treba ga ubaciti kreirat ce sam defaultni obj s def poljima
            );
        }

        [HttpPost]
        public IActionResult Create(Category objIzForme)
        {
            if (objIzForme.Name == objIzForme.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Jednaki Su????");
            }

            // ovo iznad je nacin za svoju custom poruku i validaciju

            if (ModelState.IsValid)
            {
                _db.Categories.Add(objIzForme);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }

            return View();
        }
    }
}
