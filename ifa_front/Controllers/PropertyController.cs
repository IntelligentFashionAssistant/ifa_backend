using application.DTOs;
using application.services;
using ifa_front.Helper;
using ifa_front.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ifa_front.Controllers
{
    public class PropertyController : Controller
    {

        HelperApi _api = new HelperApi();

        private readonly IPropertyService _propertyService;
        private readonly ICategoryService _categoryService;
        private readonly IGroupService _groupService;
        public PropertyController(IPropertyService propertyService , 
                                  ICategoryService categoryService,
                                  IGroupService groupService)
        {
            _propertyService = propertyService;
            _categoryService = categoryService;
            _groupService = groupService;
        }
       

        public async Task<ActionResult> IndexAsync()
        {
            var Propertys = new List<Property>();

            Propertys = _propertyService.GetAll().Select(e => new Property
            {
                Id = e.Id,
                Name = e.Name,
                //CategoryId = (long)e.CategoryId,
                Group = e.Group,
                
            }).ToList();
           
            return View(Propertys);
        }

       

        // GET: PropertyController/Create
        public async Task<ActionResult> Create()
        {
              var model = new Property();
               model.Categories = _categoryService.GetAll().Select(e => new Category
               {
                   Id = e.Id,
                   Name = e.Name,
               }).ToList();

            return View(model);
        }

        // POST: PropertyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Property model)
        {
            if(model.GroupId > 0)
            {
                _propertyService.Create(new PropertyDto
                {
                    Name = model.Name,
                    Description = model.Description,
                    //CategoryId = model.CategoryId,
                    GroupId = model.GroupId
                });
                return RedirectToAction("Index");
            }
            model.Groups = await GetAllGroups((int)model.CategoryId);
            model.Categories = _categoryService.GetAll().Select(e => new Category
            {
                Id = e.Id,
                Name = e.Name,
            }).ToList(); 
;            return View(model);
        }

        
        public ActionResult DeleteP(int id)
        {
            
             _propertyService.DeleteById(id);
             return RedirectToAction(nameof(Index));
           
        }

        public async Task<List<Category>> GetAllCategoryes()
        {

            var categorys = new List<Category>();

            HttpClient client = _api.Intial();
            HttpResponseMessage res = await client.GetAsync("category");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                categorys = JsonConvert.DeserializeObject<List<Category>>(result);
            }
            return categorys;
        }
        public async Task<List<Group>> GetAllGroups(int id)
        {
            var groups = new List<Group>();
                groups = _groupService.GetAll().Select(e => new Group
            {
                Id = e.Id,
                Category = e.CategorysNames.FirstOrDefault(),
                Name = e.Name,
                CategoryId=e.CategoryId,
            }).ToList();
           
            List<Group> listGrop = groups.Where(e => e.CategoryId == id).ToList();
            return listGrop; 
                }

    }
}
