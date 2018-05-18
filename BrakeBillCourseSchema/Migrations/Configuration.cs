namespace BrakeBillCourseSchema.Migrations
{
    using BrakeBillCourseSchema.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BrakeBillCourseSchema.Models.BrakeBillDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BrakeBillCourseSchema.Models.BrakeBillDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            DbSet<Student>.AddOrUpdate(Id = 0, Firstname = "Sara", Lastname = "Johansson");
        }
    }
}
