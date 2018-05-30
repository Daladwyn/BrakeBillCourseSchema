using BrakeBillCourseSchema.Models;
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
            using (var context = new context())
            {
                //Course CourseToAdd = context.Courses.Include("CourseStudents").Include("CourseAssignments").SingleOrDefault(c => c.CourseId == Courseid);
                //CourseToAdd.CourseStudents.Add(newStudent);
                //CourseToAdd.CourseAssignments = context.Assignments.SqlQuery("SELECT * FROM Assignments WHERE CourseId=@id", new SqlParameter("@id", Courseid)).ToList();
                //context.Courses.Add(CourseToAdd);

            }
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