using LearningDotNet.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;

namespace LearningDotNet.Controllers
{
  public class TasksController : Controller
  {
    ApplicationDbContext _context;
    public TasksController()
    {
      _context = new ApplicationDbContext();
    }

    public ActionResult Index()
    {
      return View("List");
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(string Name, int StatusId)
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
