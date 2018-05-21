using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using BrakeBillCourseSchema.Models;

namespace BrakeBillCourseSchema.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentCreateForm()
        {
            List<Course> presentCourses = new List<Course>();
            using (var context = new context())
            {
                foreach (var item in context.Courses)
                {
                    presentCourses.Add(context.Courses.Find(item.Id));
                }
            }

            //     List<Student> presentStudents = new List<Student>();
            //using (var context = new context())
            //{
            //    foreach (var item in context.Students)
            //    {
            //        presentStudents.Add(context.Students.Find(item.Id));
            //    }


            //    return View("Students", presentStudents);
            //}
            return PartialView("_StudentCreateForm", Course.presentCourses);
        }

        public ActionResult StudentCreate(string Firstname, string Lastname)
        {
            var newStudent = new Student()
            {
                Firstname = Firstname,
                Lastname = Lastname
            };

            using (var context = new context())
            {
                context.Students.Add(newStudent);
                context.SaveChanges();
            }

            return RedirectToAction("Students");
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