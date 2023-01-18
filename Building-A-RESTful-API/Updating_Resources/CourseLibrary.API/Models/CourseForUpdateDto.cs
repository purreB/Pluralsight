using CourseLibrary.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
  [CourseTitleMustBeDifferentFromDescription(ErrorMessage = "Title must be different from description")]
  public class CourseForUpdateDto
  {
    [Required(ErrorMessage = "You should fill out a title,")]
    [MaxLength(100, ErrorMessage = "The title must be no more than 100 characters")]
    public string Title { get; set; }
    [MaxLength(1500, ErrorMessage = "The description must be no more than 1500 characters")]
    public string Description { get; set; }
  }
}
