using application.DTOs;
using application.services;
using ifa_front.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ifa_front.Controllers
{
    public class GarmentController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly ICategoryService _categoryService;
        private readonly IGarmentService _garmentService;
        private readonly IWebHostEnvironment _wepHostEnvironment;
        public GarmentController(IGroupService groupService, 
                                ICategoryService categoryService,
                                IGarmentService garmentService,
                                IWebHostEnvironment wepHostEnvironment)
        {
            _groupService = groupService;
            _categoryService = categoryService;
            _garmentService = garmentService;
            _wepHostEnvironment = wepHostEnvironment;
        }
        // GET: GarmentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GarmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GarmentController/Create
        public ActionResult Create()
        {
            var model = new Garment();
            
            model.Categorys = _categoryService.GetAll().Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return View(model);
        }

        // POST: GarmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Garment garment)
        {
            Random rnd = new Random();
            var img = "";

            if (garment.Photo != null)
            {
                var FillFilePath = $"c:\\Images\\{Path.GetFileName(garment.Photo.FileName)}";
                using (var stream = new FileStream(FillFilePath, FileMode.Create))
                {
                    await garment.Photo.CopyToAsync(stream);
                  img =$"{ Path.GetFileName(garment.Photo.FileName)}";
                  
                }
            }
            
            if (garment.PropertyIds != null && garment.PropertyIds.Count() > 0 )
            {
                var model = new GarmentDto
                {
                    Name = garment.Name,
                    Description = garment.Description,
                    Price = garment.Price,
                    Brand = garment.Brand,
                    CategoryId = garment.CategoryId,
                    StoreId = rnd.Next(5, 7),
                };
                var imageList = new List<string>();
                imageList.Add(img);
                //var colorList = new List<string>() { "red","green"};

                model.Images = imageList;
                model.Properties = garment.PropertyIds;
                model.Colors = garment.Colors;

                _garmentService.Create(model);
                
                return RedirectToAction();
            }

            if (garment.CategoryId > 0)
            {
                garment.Groups = _groupService.GetGroupByCategory(garment.CategoryId)
                                   .Select(g => new Group
                                   {
                                       Id = g.Id,
                                       Name = g.Name,
                                       Properties = g.Propertys.Select(p => new Property
                                       {
                                           Name = p.Name,
                                           Id = p.Id,
                                       }).ToList(),
                                   }).ToList();
            }
            garment.Categorys = _categoryService.GetAll().Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return View(garment);
        }

        // GET: GarmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GarmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GarmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GarmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
