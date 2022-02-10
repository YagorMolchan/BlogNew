using BlogNew.Areas.Admin.Models.ViewModels;
using BlogNew.Interfaces;
using BlogNew.Models;
using BlogNew.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogNew.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }


        // GET: Admin/Category
        [HttpGet]
        public ActionResult Index()
        {
            var categories = _repo.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            _repo.Create(model);
            ViewBag.Message = "Category inserted successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _repo.GetCategory(id);
            var model = new CategoryEditViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryEditViewModel model)
        {
            var category = _repo.GetCategory(model.Id);
            category.Name = model.Name;
            if(category != null)
            {
                _repo.Edit(category);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var category = _repo.GetCategory(id);
            return View(category);
        }
    }
}