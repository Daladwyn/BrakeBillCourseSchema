namespace BrakeBillCourseSchema.Migrations
{
    using BrakeBillCourseSchema.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BrakeBillCourseSchema.Models.context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BrakeBillCourseSchema.Models.context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Students.AddOrUpdate(s => s.StudentId,
            new Student() { StudentId = 1, Firstname = "Sara", Lastname = "Johansson" },
            new Student() { StudentId = 2, Firstname = "Mats", Lastname = "Nilsson" });

            context.Teachers.AddOrUpdate(t => t.Firstname,
            new Teacher() { Firstname = "Jerker", Lastname = "Svensson", });

            context.SaveChanges();

            context.Courses.AddOrUpdate(c => c.CourseId,
            new Course() { CourseId = 1, CourseName = "Transformation101", TeacherId = 1, Description = "Transformation 101: how to transform a mouse into a Lamp." });

            context.SaveChanges();
            context.Assignments.AddOrUpdate(a => a.AssignmentId,
            new Assignment() { AssignmentName = "Transformation1", CourseId = 1, StudentId = 1, Description = "Assignment1 in Transformation. How to transform a chair into a Lamp.", IsTemplateAssignment = true, IsCompletedByStudent = false },
            new Assignment() { AssignmentName = "Transformation1", CourseId = 1, StudentId = 1, Description = "Assignment2 in Transformation. How to transform a mouse into a Lamp.", IsTemplateAssignment = true, IsCompletedByStudent = false },
            new Assignment() { AssignmentName = "Transformation1", CourseId = 1, StudentId = 1, Description = "Assignment1 in Transformation. How to transform a chair into a Lamp.", IsTemplateAssignment = false, IsCompletedByStudent = false },
            new Assignment() { AssignmentName = "Transformation1", CourseId = 1, StudentId = 1, Description = "Assignment2 in Transformation. How to transform a mouse into a Lamp.", IsTemplateAssignment = false, IsCompletedByStudent = false },
            new Assignment() { AssignmentName = "Transformation1", CourseId = 1, StudentId = 2, Description = "Assignment1 in Transformation. How to transform a chair into a Lamp.", IsTemplateAssignment = false, IsCompletedByStudent = false },
            new Assignment() { AssignmentName = "Transformation1", CourseId = 1, StudentId = 2, Description = "Assignment2 in Transformation. How to transform a mouse into a Lamp.", IsTemplateAssignment = false, IsCompletedByStudent = false });
            context.SaveChanges();
        }
    }
}
