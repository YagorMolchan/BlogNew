using BlogNew.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogNew.Models.ViewModels
{
    public class ArticleFilterModel
    {
        [DataType(DataType.DateTime)]
        [Display(Name="Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name="Finish Date")]
        public DateTime FinishDate { get; set; }

        [Display(Name = "Категория")]
        public int? CategoryId { get; set; }

        public SelectList Categories { get; set; }

        [Display(Name = "Tags")]
        public string TagText { get; set; }

        public IEnumerable<Article> Articles { get; set; }
    }
}