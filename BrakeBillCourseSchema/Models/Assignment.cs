﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrakeBillCourseSchema.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ToCourse { get; set; }
        [Required]
        public bool isCompletedByStudent { get; set; }

    }
}