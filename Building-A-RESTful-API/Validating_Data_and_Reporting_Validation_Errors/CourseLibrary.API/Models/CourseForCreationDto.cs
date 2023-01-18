using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CourseLibrary.API.ValidationAttributes;


namespace CourseLibrary.API.Models
{
  public class CourseForCreationDto
  {
    [CourseTitleMustBeDifferentFromDescription]

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(1500)]
    public string Description { get; set; }

    // public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    // {
    //   if (Title == Description)
    //   {
    //     yield return new ValidationResult("Title and Description must be different", new[] { "CourseForCreationDTO" });
    //   }
    // }

  }
}
