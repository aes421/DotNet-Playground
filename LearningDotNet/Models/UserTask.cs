using System.ComponentModel.DataAnnotations;

namespace LearningDotNet.Models {
  public class UserTask
  {
    public int Id { get; set; }

    [Required]
    public string TaskName { get; set; }

    [Required]
    public Status Status { get; set; }
  }
  

}
