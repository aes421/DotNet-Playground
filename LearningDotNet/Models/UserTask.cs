using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LearningDotNet.Models
{
  public class UserTask
  {
    public int Id { get; set; }
    public string TaskName { get; set; }
    public Status Status { get; set; }
  }
  

}
