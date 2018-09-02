using LearningDotNet.Models;
using LearningDotNet.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LearningDotNet.Controllers {
  public class TasksController : Controller {
    ApplicationDbContext _context;
    public TasksController() {
      _context = new ApplicationDbContext();
    }

    public ActionResult Index() {
      var tasks = _context.UserTasks.Include("Status").ToList();
      return View("List", tasks);
    }

    public ActionResult Create() {
      var viewModel = new CreateTaskViewModel {
        Statuses = GetStatuses()
      };

      return View(viewModel);
    }

    [HttpPost]
    public ActionResult Create(CreateTaskViewModel viewModel) {
      UserTask task = new UserTask() {
        TaskName = viewModel.TaskName,
        StatusId = viewModel.Status
      };

      _context.UserTasks.Add(task);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    public IEnumerable<Status> GetStatuses() {
      return _context.Statuses;
    }
  }
}
