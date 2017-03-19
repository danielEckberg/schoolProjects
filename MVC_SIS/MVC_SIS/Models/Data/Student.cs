using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Exercises.Models.Data
{
    public class Student:IValidatableObject
    {
        public int StudentId { get; set; }
        //[Required(ErrorMessage = "Please enter the first name")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "Please enter the last name")]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Please enter a GPA")]
        public decimal GPA { get; set; }
        public Address Address { get; set; }
        //[Required(ErrorMessage = "Please select a Major")]
        public Major Major { get; set; }
        //[AtLeastOneCourse(ErrorMessage = "Please select at least one course")]
        public List<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(FirstName))
            {
                errors.Add(new ValidationResult("Please enter the first name", new[] { "FirstName" }));
            }
            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add(new ValidationResult("Please enter the last name", new[] { "LastName" }));
            }
            if (Major.MajorId == 0)
            {
                errors.Add(new ValidationResult("Please select a major", new [] {"Major"}));
            }
            return errors;
        }
    }




}