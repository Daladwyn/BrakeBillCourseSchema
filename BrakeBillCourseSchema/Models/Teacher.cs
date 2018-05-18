using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrakeBillCourseSchema.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        public int I { get; set; }
        [MaxLength(20)]
        [Required]
        public string Firstname { get; set; }
        [MaxLength(20)]
        [Required]
        public string Lastname { get; set; }

        public List<Course> Courses = new List<Course>();
    }
}