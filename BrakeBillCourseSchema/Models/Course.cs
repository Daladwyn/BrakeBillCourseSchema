using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrakeBillCourseSchema.Models
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [MaxLength(20)]
        [Required]
        public string CourseName { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        
        public List<Assignment> CourseAssignments { get; set; }
        
        public List<Student> CourseStudents { get; set; }

    }
}