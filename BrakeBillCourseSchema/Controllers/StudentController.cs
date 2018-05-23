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
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index2()
        {
            return View("~/Views/Home/Students");
        }

        //[HttpPost]
        public ActionResult StudentCreateForm()
        {
            List<Course> presentCourses = new List<Course>();
            using (var context = new context())
            {
                foreach (var item in context.Courses)
                {
                    presentCourses.Add(context.Courses.Find(item.CourseId));
                }
            }
            return PartialView("_StudentCreateForm", presentCourses);
        }

        [HttpPost]
        public ActionResult StudentCreate([Bind(Include = "Firstname,Lastname,id")] Student newStudent)
        {
            if (ModelState.IsValid)
            {
                using (var context = new context())
                {
                    context.Students.Add(newStudent);
                    context.SaveChanges();
                }
                return PartialView("_StudentCreate");
            }
            else
            {
                return PartialView("_StudentCreate");
            }
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
            List<Student> presentStudents = new List<Student>();
            using (var context = new context())
            {
                foreach (var item in context.Students)
                {
                    presentStudents.Add(context.Students.Find(item.StudentId));
                }
                for (int i = 0; i <= presentStudents.Count(); i++)
                {


                    if (presentStudents[i].StudentId == id)
                    {
                        // presentStudents.Remove(presentStudents[i]);
                        context.Students.Remove(presentStudents[i]);
                        context.SaveChanges();
                        presentStudents = null;
                        return PartialView("_DeletedObject");
                    }
                }
            }
            presentStudents = null;
            return PartialView("_DeletedObject");
        }
    }
}