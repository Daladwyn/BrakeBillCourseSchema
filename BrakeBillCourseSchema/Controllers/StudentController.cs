using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrakeBillCourseSchema.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentCreate(int id)
        {
            return PartialView();
        }

        public ActionResult StudentEdit(int id)
        {
            return PartialView();
        }

        public ActionResult StudentListCourses(int id)
        {
            return PartialView();
        }

        public ActionResult StudentDelete(int id)
        {
            return PartialView();
        }
    }
}