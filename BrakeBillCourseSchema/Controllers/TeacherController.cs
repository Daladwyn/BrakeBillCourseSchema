using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrakeBillCourseSchema.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TeacherCreate(int id)
        {
            return PartialView();
        }

        public ActionResult TeacherEdit(int id)
        {
            return PartialView();
        }

        public ActionResult TeacherShowCourses(int id)
        {
            return PartialView();
        }

        public ActionResult TeacherDelete(int id)
        {
            return PartialView();
        }
    }
}