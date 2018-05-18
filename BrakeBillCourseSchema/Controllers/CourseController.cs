using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrakeBillCourseSchema.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CourseCreate(int id)
        {
            return PartialView();
        }

        public ActionResult CourseEdit(int id)
        {
            return PartialView();
        }

        public ActionResult CourseDetails(int id)
        {
            return PartialView();
        }

        public ActionResult CourseDelete(int id)
        {
            return PartialView();
        }
    }
}