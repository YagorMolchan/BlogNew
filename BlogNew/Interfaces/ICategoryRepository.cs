using BlogNew.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogNew.Interfaces
{
    public interface ICategoryRepository
    {
        void Create(Category category);

        void Edit(Category category);

        void Delete(int id);

        Category GetCategory(int id);

        IEnumerable<Category> GetCategories();
    }
}
