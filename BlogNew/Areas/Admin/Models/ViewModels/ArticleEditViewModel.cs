using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogNew.Areas.Admin.Models.ViewModels
{
    public class ArticleEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string ShortDescription { get; set; }

        public string Text { get; set; }

        public string TagText { get; set; }
    }
}