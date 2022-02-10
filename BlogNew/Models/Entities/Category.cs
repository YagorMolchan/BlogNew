using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogNew.Models.Entities
{
    public class Category
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Article> Articles { get; set; }

        public Category()
        {
            Articles = new List<Article>();
        }
    }
}