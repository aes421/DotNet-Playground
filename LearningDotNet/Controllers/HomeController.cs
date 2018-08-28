using LearningDotNet.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;

namespace LearningDotNet.Controllers {
  public class HomeController : Controller{
  ApplicationDbContext _context;
  public HomeController() {
    _context = new ApplicationDbContext();
  }

  public ActionResult Index()
  {
      return View();
  }

  public ActionResult About()
  {
      ViewBag.Message = "Your application description page.";

      return View();
  }

  public ActionResult CreateEdit()
  {
      return View();
  }
    [HttpPost]
    public ActionResult CreateEdit(UserTask task)
    {
      _context.UserTasks.Add(task);
      _context.SaveChanges();
      return View();
    }

    public string GetStatuses() {
      return JsonConvert.SerializeObject(_context.Statuses.ToList());
    }
    }
}
