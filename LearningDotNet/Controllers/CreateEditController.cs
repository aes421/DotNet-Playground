using LearningDotNet.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;

namespace LearningDotNet.Controllers
{
  public class CreateEditController : Controller
  {
    ApplicationDbContext _context;
    public CreateEditController()
    {
      _context = new ApplicationDbContext();
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult CreateEdit()
    {
      return View();
    }
    [HttpPost]
    public ActionResult CreateEdit(string Name, int StatusId)
    {
      UserTask task = new UserTask()
      {
        TaskName = Name,
        Status = _context.Statuses.Where(x => x.Id == StatusId).FirstOrDefault()
      };
      
      _context.UserTasks.Add(task);
      _context.SaveChanges();
      return View();
    }

    public string GetStatuses()
    {
      return JsonConvert.SerializeObject(_context.Statuses.ToList());
    }
  }
}
