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

            context.Students.AddOrUpdate(s => s.Id,
            new Student() { Id = 0, Firstname = "Sara", Lastname = "Johansson" },
            new Student() { Id = 1, Firstname = "Mats", Lastname = "Nilsson" });

            context.Teachers.AddOrUpdate(t => t.Firstname,
            new Teacher() { Firstname = "Jerker", Lastname = "Svensson" });

            context.Courses.AddOrUpdate(c => c.Id,
            new Course() { Id = 0, Name = "Transformation", hasTeacher = 0 });


            context.Assignments.AddOrUpdate(a => a.Id,
            new Assignment { Id = 0, Name = "Transformation1", ToCourse = 0, ToStudent = 0, Description = "Transformation 101: how to transform a mouse into a Lamp.", isCompletedByStudent = false });
            context.SaveChanges();
        }
    }
}
