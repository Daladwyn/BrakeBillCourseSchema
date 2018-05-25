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
        public ActionResult ShowStudent(int id)
        {
            Student studentToShow = new Student();
            using (var context = new context())
            {
                studentToShow = context.Students.SingleOrDefault(s => s.StudentId == id);
            };
            return PartialView("_ShowStudent",studentToShow);
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
        public ActionResult StudentCreate([Bind(Include = "Firstname,Lastname,Courseid")] Student newStudent)
        {
            if (ModelState.IsValid)
            {
                using (var context = new context())
                {
                    context.Students.Add(newStudent);
                    newStudent = null;
                    context.SaveChanges();
                }
                return View ("students");
            }
            return RedirectToAction("students", "Home");
        }

        public ActionResult StudentEdit(int id)
        {
            return PartialView();
        }

        public ActionResult StudentListCourses(int id)
        {
            Student studentToShow = new Student();
            using (var context = new context())
            {
                studentToShow = context.Students.Include(c => c.StudentCourses).SingleOrDefault(s => s.StudentId == id);

            };

            return PartialView("_StudentListCourses",studentToShow);
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