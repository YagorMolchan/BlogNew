using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogNew.Models.Entities
{
    public class Article
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string ShortDescription { get; set; }

        public string ImagePath { get; set; }

        public string Text { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string TagText { get; set; }


        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        
    }
}