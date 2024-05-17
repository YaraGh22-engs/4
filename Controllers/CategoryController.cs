using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Cart.Data;
using Shopping_Cart.Models;
using Shopping_Cart.Services;

namespace Shopping_Cart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ICategoryService categoryService, ApplicationDbContext dbContext)
        {
            _categoryService = categoryService;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var cat = _categoryService.GetAll();
            return View(cat);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _categoryService.Create(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _dbContext.categories.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category cat)
        {
            if (cat.Name == "100")
            {
                ModelState.AddModelError("Name", "Name can't equal 100");
            }
            if (ModelState.IsValid)
            {
                _dbContext.categories.Update(cat);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(cat);
            }
        }

        public IActionResult Delete(int Id)
        {
            _categoryService.Delete(Id);
            return RedirectToAction("Index");
        }

    }
}
