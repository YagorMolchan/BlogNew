using BlogNew.Interfaces;
using BlogNew.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogNew.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _aRepo;
        private readonly ICategoryRepository _cRepo;

        public ArticleController(IArticleRepository aRepo, ICategoryRepository cRepo)
        {
            _aRepo = aRepo;
            _cRepo = cRepo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var list = _aRepo.GetArticles();
            var model = new ArticleFilterModel
            {
                Categories = new SelectList(_cRepo.GetCategories(), "Id", "Name"),
                Articles = list
            };
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Index(ArticleFilterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //}
    }
}