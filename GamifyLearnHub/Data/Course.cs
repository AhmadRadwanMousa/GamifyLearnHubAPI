﻿using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Data
{
    public partial class Course
    {
        public Course()
        {
            CoursesequenceCourses = new HashSet<Coursesequence>();
            CoursesequencePerviouscourses = new HashSet<Coursesequence>();
        }

        public decimal Courseid { get; set; }
        public string Courselevel { get; set; } = null!;
        public string Coursename { get; set; } = null!;
        public string Courseimage { get; set; } = null!;
        public decimal Examweight { get; set; }
        public decimal Assignmentweight { get; set; }
        public decimal Quizzezweight { get; set; }

        public virtual ICollection<Coursesequence> CoursesequenceCourses { get; set; }
        public virtual ICollection<Coursesequence> CoursesequencePerviouscourses { get; set; }
    }
}