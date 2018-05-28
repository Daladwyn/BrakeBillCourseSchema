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
            new Student() { StudentId = 0, Firstname = "Sara", Lastname = "Johansson" },
            new Student() { StudentId = 1, Firstname = "Mats", Lastname = "Nilsson" });

            context.Teachers.AddOrUpdate(t => t.Firstname,
            new Teacher() { Firstname = "Jerker", Lastname = "Svensson",  });

            context.Courses.AddOrUpdate(c => c.CourseId,
            new Course() { CourseId = 1, Name = "Transformation101", TeacherId = 0, Description = "Transformation 101: how to transform a mouse into a Lamp." });


            context.Assignments.AddOrUpdate(a => a.AssignmentId,
            new Assignment { AssignmentId = 0, Name = "Transformation1", CourseId = 1, StudentId = 0, Description = "Assignment1 in Transformation. How to transform a mouse into a Lamp.", IsCompletedByStudent = false });
            context.SaveChanges();
        }
    }
}
