using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogNew.Areas.Admin.Models.ViewModels
{
    public class ArticleCreateViewModel
    {
        [Required]
        [Display(Name="Название")]
        public string Name { get; set; }

        [Display(Name="Краткое описание")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name="Текст статьи")]
        public string Text { get; set; }

        [Display(Name="Картинка")]
        public string ImagePath { get; set;  }

        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        [Display(Name="Категория")]
        public int CategoryId { get; set; }
        public SelectList  Categories { get; set; }

        [Display(Name="Теги")]
        public string TagText { get; set; }
    }
}