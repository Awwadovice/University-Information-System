﻿namespace UniversityInformationSystem.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Users;
    using Utillities.Constants;

    public class Course
    {
        public Course()
        {
            this.EnrolledStudents = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.CourseNameLength)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [StringLength(ValidationConstants.CourseDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [Range(ValidationConstants.MinCredits, ValidationConstants.MaxCredits,
            ErrorMessage = ValidationConstants.ValidationErrorMessages.CourseCreditsErrorMsg)]
        public double Credits { get; set; }

        [Required]
        public bool IsOpen { get; set; }

        public virtual ICollection<StudentCourse> EnrolledStudents { get; set; }

        public int? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
