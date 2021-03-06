﻿using BrakeBillCourseSchema.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public ActionResult ListACourse(int id)
        {
            Teacher CourseTeacher = new Teacher();
            Course presentCourse = new Course();
            using (var context = new context())
            {
                //presentCourse = context.Courses.SqlQuery("SELECT * FROM Courses JOIN Teachers ON Courses.TeacherId=Teachers.TeachersId WHERE CourseId=@id", new SqlParameter ("@id", id)).;
                presentCourse = context.Courses.SingleOrDefault(c => c.CourseId == id);
                //CourseTeacher = context.Entry(presentCourse).Collection(t => t.Teachers).Load();
            }
            return PartialView("_ListACourse", presentCourse);
        }

        public ActionResult CourseCreateForm()
        {
            return PartialView("_CourseCreateForm");
        }

        public ActionResult CourseCreate([Bind(Include = "CourseName,Description")] Course newCourse)
        {
            if (ModelState.IsValid)
            {
                using (var context = new context())
                {
                    newCourse.TeacherId = 1;
                    context.Courses.Add(newCourse);
                    int numberOfSavedObjects = context.SaveChanges();
                }
            }
            return RedirectToAction("Courses", "Home");
        }
        //            )
        //{
        //    using (var context = new context())
        //    {
        //        //Course CourseToAdd = context.Courses.Include("CourseStudents").Include("CourseAssignments").SingleOrDefault(c => c.CourseId == Courseid);
        //        //CourseToAdd.CourseStudents.Add(newStudent);
        //        //CourseToAdd.CourseAssignments = context.Assignments.SqlQuery("SELECT * FROM Assignments WHERE CourseId=@id", new SqlParameter("@id", Courseid)).ToList();
        //        //context.Courses.Add(CourseToAdd);

        //    }
        //    return PartialView();
        //}

        public ActionResult CourseEdit(int id)
        {
            return PartialView();
        }

        public ActionResult CourseDetails(int id)
        {
            using (var context = new context())
            {


                var presentCourseDetails = context.Courses.Include("CourseStudents").Include("CourseAssignments").SingleOrDefault(c => c.CourseId == id);
                return PartialView("_CourseDetails", presentCourseDetails);
            }
        }

        public ActionResult CourseTeacher(int id)
        {
            List<Teacher> AllTeachers = new List<Teacher>();
            Teacher courseTeacher = new Teacher();
            using (var context = new context())
            {
                // var courseTeacher = context.Teachers.SqlQuery("SELECT * FROM Teachers JOIN Courses ON Teachers.TeachingInCourse.CourseId=Courses.CourseId WHERE CourseId=@id", new SqlParameter("@id", id));
                foreach (var teacher in context.Teachers.Include("TeachingInCourses"))
                {
                    AllTeachers.Add(teacher);
                }
            }
            foreach (var teacher in AllTeachers)
            {
                foreach (var course in teacher.TeachingInCourses)
                {
                    if (course.CourseId == id)
                    {
                        courseTeacher.Firstname = teacher.Firstname;
                        courseTeacher.Lastname = teacher.Lastname;
                    }
                }
            }
            return PartialView("_CourseTeacher", courseTeacher);
        }
    public ActionResult CourseDelete(int id)
    {
        return PartialView();
    }
    }

}
