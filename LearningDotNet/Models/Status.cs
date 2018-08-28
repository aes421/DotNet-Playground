using System.ComponentModel.DataAnnotations;

namespace LearningDotNet.Models {
  public class Status
  {
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }
  }
}
