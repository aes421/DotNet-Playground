using LearningDotNet.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningDotNet.ViewModels {
  public class CreateTaskViewModel {

    public int Id { get; set; }

    [Required]
    [Display(Name = "Description")]
    public string TaskName { get; set; }

    [Required]
    public int Status { get; set; }

    public IEnumerable<Status> Statuses { get; set; }
  }
}
