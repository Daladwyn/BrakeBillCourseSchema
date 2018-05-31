using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrakeBillCourseSchema.Models
{
    [Table("Assignments")]
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        [Required]
        [MaxLength(20)]
        public string AssignmentName { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public bool IsTemplateAssignment { get; set; }
        [Required]
        public bool IsCompletedByStudent { get; set; }
    }
}