using application.DTOs;
using application.services;
using ifa_front.Helper;
using ifa_front.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ifa_front.Controllers
{
    public class GroupController : Controller
    {
        HelperApi _api = new HelperApi();
        private readonly IGroupService _groupService;
        private readonly ICategoryService _categoryService;
      public GroupController(IGroupService groupService, ICategoryService categoryService)
        {
            _groupService = groupService;
            _categoryService = categoryService;
        }
        public async Task<ActionResult> Index()
        {
            var groups = new List<Group>();

             var data = _groupService.GetAll();
            groups =  data.Select(e => new Group
            {
                Id = e.Id,
                Category = e.CategorysNames.First(),
                Name = e.Name,

            }).ToList();
            //HttpClient client = _api.Intial();
            //HttpResponseMessage res = await client.GetAsync("api/Group");

            //if (res.IsSuccessStatusCode)
            //{
            //    var result = res.Content.ReadAsStringAsync().Result;
            //    groups = JsonConvert.DeserializeObject<List<Group>>(result);
            //}
            return View(groups);
        }

        // GET: GroupController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GroupController/Create
        public async Task<ActionResult> Create()
        {
            Group group = new Group();
            group.Categorys = _categoryService.GetAll().Select(e => new Category
            {
                Id = e.Id,
                Name = e.Name,
            }).ToList();
            return View(group);
        }

        // POST: GroupController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Group model)
        {
            
            if (model.CategoryId > 0 && model.Name != null && model.Description != null)
            {
                _groupService.Create(new GroupDto
                {
                    Name = model.Name,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                });
                return RedirectToAction("Index");
            }

            //Group group = await GatAllCategory();
            return View(model);
        }
        public ActionResult DeleteG(int id)
        {

            _groupService.DeleteById(id);
            return RedirectToAction(nameof(Index));

        }

        
    }
}
