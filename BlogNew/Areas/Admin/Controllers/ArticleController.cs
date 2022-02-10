using BlogNew.Areas.Admin.Models.ViewModels;
using BlogNew.Interfaces;
using BlogNew.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BlogNew.Models;
using System.Text;

namespace BlogNew.Areas.Admin.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {

        private readonly IArticleRepository _aRepo;       
        private readonly ICategoryRepository _cRepo;
        private readonly IUserRepository _uRepo;        

        public ArticleController(IArticleRepository aRepo, ICategoryRepository cRepo, IUserRepository uRepo)
        {
            _aRepo = aRepo;
            _cRepo = cRepo;
            _uRepo = uRepo;
        }
       
        public ActionResult Index()
        {
            return View(_aRepo.GetArticles());
        }


        [HttpGet]
        public ActionResult Create()
        {
            var model = new ArticleCreateViewModel
            {
                Categories = new SelectList(_cRepo.GetCategories(), "Id", "Name")
            };           

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ArticleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    fileName = Path.Combine(Server.MapPath("~/Content/"), fileName);
                    model.ImagePath = fileName;
                    model.ImageFile.SaveAs(fileName);
                }

                var article = new Article
                {
                    Date = DateTime.Now,
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    Category = _cRepo.GetCategory(model.CategoryId),
                    ShortDescription = model.ShortDescription,
                    ImagePath = model.ImagePath,
                    Text = model.Text,
                    TagText = model.TagText,
                    ApplicationUserId = User.Identity.GetUserId(),
                    User = _uRepo.GetUser(User.Identity.GetUserId())                    
                };

                

                _aRepo.Create(article);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var article = _aRepo.GetArticle(id);
            
            var model = new ArticleEditViewModel
            {
                Id = article.Id,
                Name = article.Name,
                ShortDescription = article.ShortDescription,
                Text = article.Text,
                ImagePath = article.ImagePath,
                TagText = article.TagText
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ArticleEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var article = _aRepo.GetArticle(model.Id);
                article.Name = model.Name;
                article.ShortDescription = model.ShortDescription;
                article.Text = model.Text;
                article.TagText = model.TagText;

                _aRepo.Edit(article);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _aRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var article = _aRepo.GetArticle(id);
            return View(article);
        }

    }
}