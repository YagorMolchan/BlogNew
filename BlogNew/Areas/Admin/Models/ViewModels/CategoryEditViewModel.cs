using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogNew.Areas.Admin.Models.ViewModels
{
    public class CategoryEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        
        public string Name { get; set; }
    }
}