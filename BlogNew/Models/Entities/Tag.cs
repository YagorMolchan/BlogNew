using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogNew.Models.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Article> Articles { get; set; }

        public Tag()
        {
            Articles = new List<Article>();
        }
    }
}