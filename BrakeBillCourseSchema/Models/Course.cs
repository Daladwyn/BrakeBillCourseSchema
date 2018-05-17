using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrakeBillCourseSchema.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int hasTeacher { get; set; }

        public List<Assignment> CourseAssignments = new List<Assignment>();
        public List<Student> Students = new List<Student>();

    }
}