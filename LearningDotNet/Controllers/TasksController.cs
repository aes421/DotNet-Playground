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
    
    [HttpGet]
    public ActionResult Index() {
      var tasks = _context.UserTasks.Include("Status").ToList();
      return View("List", tasks);
    }

    [HttpGet]
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

    [HttpGet]
    public ActionResult Edit(int id) {
      //Make sure task in route exists
      var task = _context.UserTasks.Where(t => t.Id == id).FirstOrDefault();

      if (task == null) {
        return RedirectToAction("Index");
      }

      var viewModel = new CreateTaskViewModel {
        Statuses = GetStatuses(),
        TaskName = task.TaskName,
        Status = task.StatusId
      };

      return View("Edit", viewModel);
    }

    public IEnumerable<Status> GetStatuses() {
      return _context.Statuses;
    }
  }
}
