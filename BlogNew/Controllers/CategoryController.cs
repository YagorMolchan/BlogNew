using BlogNew.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogNew.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _cRepo;

        public CategoryController(ICategoryRepository cRepo)
        {
            _cRepo = cRepo;
        }


        // GET: Category
        public ActionResult Index()
        {
            var list = _cRepo.GetCategories();
            return View(list);
        }
    }
}