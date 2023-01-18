using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CourseLibrary.API.ValidationAttributes;


namespace CourseLibrary.API.Models
{
  [CourseTitleMustBeDifferentFromDescription(ErrorMessage = "Title must be different from description")]

  public class CourseForCreationDto
  {
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(100, ErrorMessage = "Title is too long")]
    public string Title { get; set; }

    [MaxLength(1500, ErrorMessage = "Description is too long")]
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
