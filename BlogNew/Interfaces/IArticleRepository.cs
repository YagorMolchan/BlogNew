using BlogNew.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogNew.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetArticles();

        IEnumerable<Article> GetArticles(DateTime startDate, DateTime finishDate);

        IEnumerable<Article> GetArticles(DateTime startDate, DateTime finishDate, int? categoryId);        

        IEnumerable<Article> GetArticles(int? categoryId);

        Article GetArticle(int id);

        void Create(Article article);

        void Edit(Article article);

        void Delete(int id);
    }
}
