using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrakeBillCourseSchema.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AssignmentEdit(int id)
        {
            return PartialView();
        }

        public ActionResult AssignmentDescription(int id)
        {
            return PartialView();
        }

        public ActionResult AssignmentDelete(int id)
        {
            return PartialView();
        }

        public ActionResult AssignmentCreate()
        {
            return PartialView();
        }
    }
}