using BrakeBillCourseSchema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrakeBillCourseSchema.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AssignmentEdit(int id)
        {
            return PartialView();
        }

        public ActionResult AssignmentDescription(int id)
        {
            return PartialView();
        }

        public ActionResult AssignmentDelete(int id)
        {
            return PartialView();
        }

        public ActionResult AssignmentCreateForm()
        {
            List<Course> presentCourses = new List<Course>();
            using (var context = new context())
            {
                foreach (var item in context.Courses)
                {
                    presentCourses.Add(context.Courses.Find(item.CourseId));
                }
            }
            return PartialView("_AssignmentCreateForm", presentCourses);
        }

        public ActionResult AssignmentCreate([Bind(Include = "AssignmentName, Description")] Assignment newAssignmet, int Courseid)
        {
            newAssignmet.CourseId = Courseid;
            newAssignmet.StudentId = 999999;
            newAssignmet.IsTemplateAssignment = true;
            newAssignmet.IsCompletedByStudent = false;
            if (ModelState.IsValid)
            {
                using (var context = new context())
                {
                    context.Assignments.Add(newAssignmet);
                    context.SaveChanges();
                }
                return RedirectToAction("Assignments", "Home");
            }
            return RedirectToAction("Assignments", "Home");
        }
    }
}