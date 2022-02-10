using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogNew.Areas.Admin.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        

        // GET: Admin/Manage
        public ActionResult Index(string userName)
        {
            ViewBag.UserName = userName;
            return View();
        }
    }
}