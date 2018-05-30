using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using BrakeBillCourseSchema.Models;
using System.Data.SqlClient;

namespace BrakeBillCourseSchema.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult StudentListAssignment(int id)
        {
            List<Assignment> AssignmentsToShow = new List<Assignment>();
            Student studentToShow = new Student();
            using (var context = new context())
            {
                studentToShow = context.Students.Include("StudentAssignments").SingleOrDefault(s => s.StudentId == id);
                foreach (var assignment in context.Assignments)
                {
                    if (assignment.StudentId == studentToShow.StudentId)
                    {
                        studentToShow.StudentAssignments.Add(assignment);
                    }
                }
            };
            return PartialView("_StudentListAssignment", studentToShow);
        }

        public ActionResult StudentListCourses(int id)
        {
            //List<Course> coursesToShow = new List<Course>();
            using (var context = new context())
            {
                Student studentToShow = context.Students.Include("StudentCourses").SingleOrDefault(s => s.StudentId == id);
                //foreach (var courseitem in context.Courses)
                //{
                //    foreach (var student in courseitem.CourseStudents)
                //    {
                //        if (student.StudentId == studentToShow.StudentId)
                //        {
                //            studentToShow.StudentCourses.Add(courseitem);
                //        }
                //    }
                //    //coursesToShow.Add(context.Courses.Include("Students").Where(s => s.StudentId == id).ToList();
                //}
                return PartialView("_StudentListCourses", studentToShow);
            };
        }

        // GET: Student
        [HttpGet]
        public ActionResult ShowStudent(int id)
        {
            Student studentToShow = new Student();
            using (var context = new context())
            {

                studentToShow = context.Students.SingleOrDefault(s => s.StudentId == id);
            };
            return PartialView("_ShowStudent", studentToShow);
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
        public ActionResult StudentCreate([Bind(Include = "Firstname,Lastname")] Student newStudent, int Courseid)
        {
            if (ModelState.IsValid)
            {
                using (var context = new context())
                {

                    newStudent.StudentCourses = context.Courses.SqlQuery("SELECT * FROM Courses WHERE CourseId=@id", new SqlParameter("@id", Courseid)).ToList();
                    newStudent.StudentAssignments = context.Assignments.SqlQuery("SELECT * FROM Assignments WHERE CourseId=@id", new SqlParameter("@id", Courseid)).ToList();
                    foreach (var Assignment in newStudent.StudentAssignments)
                    {
                        Assignment.StudentId = 999999999;
                    }
                    context.Students.Add(newStudent);
                    //newStudent = null;
                    context.SaveChanges();
                    newStudent.StudentId= context.Students.SqlQuery("SELECT * FROM Students WHERE // ")//Här söks eleven upp med med för och efternamn och StudentId som sedan skall användas att sättas till AssingmentId.Studentid
                }
                return View("students");
            }
            return RedirectToAction("students", "Home");
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

        public ActionResult StudentEdit(int id)
        {
            return PartialView();
        }
    }
}