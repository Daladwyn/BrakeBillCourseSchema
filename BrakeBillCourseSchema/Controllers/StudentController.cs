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

        //[HttpPost]
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
            return PartialView("_StudentCreateForm", presentCourses);
        }

        public ActionResult StudentCreate(string Firstname, string Lastname, int id)
        {
            using (var context = new context())
            {
                var newStudent = new Student()
                {
                    Firstname = Firstname,
                    Lastname = Lastname,
                    Course_Id = id
                };
                context.Students.Add(newStudent);
                context.SaveChanges();
            }
            return PartialView("_StudentCreate");
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
                    presentStudents.Add(context.Students.Find(item.Id));
                }
                for (int i = 0; i <= presentStudents.Count; i++)
                {
                    for (int y = 1; y <= id; y++)
                    {
                        if (presentStudents[i].Id == y && y==id)
                        {
                            presentStudents.Remove(presentStudents[i]);
                            context.Students.Remove(presentStudents[i]);
                            context.SaveChanges();
                            return PartialView("_DeletedObject");
                        }
                    }
                }
            }
            presentStudents = null;
            return PartialView("_DeletedObject");
        }
    }
}