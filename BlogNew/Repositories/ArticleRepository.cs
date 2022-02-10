using BlogNew.Interfaces;
using BlogNew.Models;
using BlogNew.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogNew.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ArticleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _dbContext.Articles.ToList();
        }

        public Article GetArticle(int id)
        {
            return _dbContext.Articles.FirstOrDefault(a => a.Id == id);
        }

        public void Create(Article article)
        {
            _dbContext.Articles.Add(article);
            _dbContext.SaveChanges();
        }

        public void Edit(Article article)
        {
            _dbContext.Entry(article).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var article = this.GetArticle(id);
            _dbContext.Articles.Remove(article);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Article> GetArticles(DateTime startDate, DateTime finishDate)
        {
            var list = _dbContext.Articles.Where(a => a.Date >= startDate && a.Date <= finishDate).ToList();
            return list;
        }

        public IEnumerable<Article> GetArticles(DateTime startDate, DateTime finishDate, int? categoryId)
        {
            var list = _dbContext.Articles.Where(a => a.Date >= startDate && a.Date <= finishDate && a.CategoryId == categoryId).ToList();
            return list;
        }

        public IEnumerable<Article> GetArticles(int? categoryId)
        {
            var list = _dbContext.Articles.Where(a => a.CategoryId == categoryId).ToList();
            return list;
        }
    }
}