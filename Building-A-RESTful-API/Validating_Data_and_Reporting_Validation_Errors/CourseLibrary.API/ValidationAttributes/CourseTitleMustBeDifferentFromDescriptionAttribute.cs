using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CourseLibrary.API.Models;

namespace CourseLibrary.API.ValidationAttributes
{
  public class CourseTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var course = (CourseForCreationDto)validationContext.ObjectInstance;
      if (course.Title == course.Description)
      {
        return new ValidationResult("The description and title must be different",
        new[] { nameof(CourseForCreationDto.Title), nameof(CourseForCreationDto) });
      }
      return ValidationResult.Success;
    }
  }
}