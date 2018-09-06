using System.ComponentModel.DataAnnotations;

namespace LearningDotNet.Models {
  public class UserTask
  {
    public int Id { get; set; }

    [Required]
    public string TaskName { get; set; }

    [Required]
    public int StatusId { get; set; }

    public Status Status { get; set; }

    [Required]
    [StringLength(128)]
    public string UserId { get; set; }

    public ApplicationUser User { get; set; }
  }
  

}
