using application.services;
using ifa_front.Helper;
using ifa_front.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ifa_front.Controllers
{
    public class CategoryController : Controller
    {
        HelperApi _api = new HelperApi();

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        

        public async Task<ActionResult> Index()
        {
            var categorys = new List<Category>();
             
             categorys = _categoryService.GetAll().Select(e => new Category
             {
                 Id = e.Id,
                 Name = e.Name,
                 Description = e.Description
             }).ToList();    
            return View(categorys);
        }

        

        
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {

            if (ModelState.IsValid)
            {
                _categoryService.Create(new CategoryDto
                {
                    Name = model.Name,
                    Description = model.Description,
                });
                return RedirectToAction("Index");
            }

            return View(model);
        }

        

        
        
    }
}
