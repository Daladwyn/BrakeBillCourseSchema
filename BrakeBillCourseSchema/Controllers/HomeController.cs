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
                    presentStudents.Add(context.Students.Find(item.StudentId));
                }
            }
            return View("Students", presentStudents);
        }

        public ActionResult Teachers()
        {
            ViewBag.Message = "Brakebills teachers.";
            List<Teacher> presentTeachers = new List<Teacher>();
            using (var context = new context())
            {
                foreach (var item in context.Teachers)
                {
                    presentTeachers.Add(context.Teachers.Find(item.TeacherId));
                }
            }
            return View("Teachers", presentTeachers);
        }

        public ActionResult Courses()
        {
            ViewBag.Message = "Brakebills Course Programme.";
            
            List<Course> presentCourses = new List<Course>();
            using (var context = new context())
            {
                foreach (var item in context.Courses)
                {
                    presentCourses.Add(context.Courses.Find(item.CourseId));
                }
            }
            return View("Courses", presentCourses);
        }

        public ActionResult Assignments()
        {
            ViewBag.Message = "Brakebills Course Assignments.";
            List<Assignment> presentAssignments = new List<Assignment>();
            using (var context = new context())
            {
                foreach (var item in context.Assignments)
                {
                    presentAssignments.Add(context.Assignments.Find(item.AssignmentId));
                }
            }
            return View("Assignments", presentAssignments);
        }
    }
}