using BrakeBillCourseSchema.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public ActionResult TeacherCreateForm()
        {
            List<Course> presentCourses = new List<Course>();
            using (var context = new context())
            {
                foreach (var item in context.Courses)
                {
                    presentCourses.Add(context.Courses.Find(item.CourseId));
                }
            }
            return PartialView("_TeacherCreateForm", presentCourses);
        }

        public ActionResult TeacherCreate([Bind(Include = "Firstname,Lastname")] Teacher newTeacher, int Courseid)
        {
            if (ModelState.IsValid)
            {
                using (var context = new context())
                {
                    context.Teachers.Add(newTeacher);
                    int numberOfChanges = context.SaveChanges(); //get hold of how many objects that was saved.
                    if (numberOfChanges >= 1) //if more than one is returned the save was a success and fetch then relevant data from database
                    {
                        newTeacher.TeachingInCourses = context.Courses.SqlQuery("SELECT * FROM Courses WHERE CourseId=@id", new SqlParameter("@id", Courseid)).ToList();
                        context.SaveChanges();
                    }
                    return RedirectToAction("Teachers", "Home");
                }
            }
            else
            {
                return RedirectToAction("Teachers", "Home");
            }
        }

        public ActionResult TeacherEdit(int id)
        {
            return PartialView();
        }

        public ActionResult TeacherList(int id)
        {
            Teacher TeacherToList = new Teacher();
            using (var context = new context())
            {
                TeacherToList = context.Teachers.SingleOrDefault(t => t.TeacherId == id);
            }
            return PartialView("_TeacherList", TeacherToList);
        }

        public ActionResult TeacherShowCourses(int id)
        {
            Teacher listATeacher = new Teacher();
            using (var context = new context())
            {
                listATeacher = context.Teachers.Include("Courses").SingleOrDefault(t => t.TeacherId == id);

            }
            return PartialView("_TeacherShowCourses", listATeacher);
        }

        //public ActionResult TeacherHideCourses(int id)
        //{
        //    return PartialView("_TeacherList", )
        //}

        public ActionResult TeacherDelete(int id)
        {
            List<Teacher> presentTeachers = new List<Teacher>();
            using (var context = new context())
            {
                foreach (var item in context.Teachers)
                {
                    presentTeachers.Add(context.Teachers.Find(item.TeacherId));
                }
                for (int i = 0; i <= presentTeachers.Count(); i++)
                {
                    if (presentTeachers[i].TeacherId == id)
                    {
                        context.Teachers.Remove(presentTeachers[i]);
                        context.SaveChanges();
                        presentTeachers = null;
                        return PartialView("_DeletedObject");
                    }
                }
            }
            presentTeachers = null;
            return PartialView("_DeletedObject");
        }
    }
}