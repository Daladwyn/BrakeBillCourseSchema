using BrakeBillCourseSchema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BrakeBillCourseSchema.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Students()
        {
            ViewBag.Message = "Registered students.";
            List<Student> presentStudents = new List<Student>();
            using (var context = new context())
            {
                foreach (var item in context.Students)
                {
                    presentStudents.Add(context.Students.Find(item.Id));
                }


                return View("Students", presentStudents);
            }
        }

        public ActionResult Teachers()
        {
            ViewBag.Message = "Brakebills teachers.";

            return View();
        }

        public ActionResult Courses()
        {
            ViewBag.Message = "Brakebills Course Programme.";
            return View();
        }

        public ActionResult Assignments()
        {
            ViewBag.Message = "Brakebills Course Assignments.";
            return View();
        }
    }
}