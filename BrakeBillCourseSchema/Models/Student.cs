using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrakeBillCourseSchema.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(20)]
        [Required]
        public string Firstname { get; set; }
        [MaxLength(20)]
        [Required]
        public string Lastname { get; set; }
        [Required]
        public List<Course> StudentCourses = new List<Course>();
        public List<Assignment> StudentAssignments = new List<Assignment>();
    }
}