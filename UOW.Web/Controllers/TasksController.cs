using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoDDD.BLL.Repositories;
using ToDoDDD.BLL.UOW;
using ToDoDDD.DAL.Entities;

namespace ToDoDDD.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly UnitOfWork _uow;
        public TasksController( UnitOfWork uow )
        {
            _uow = uow;
        }

        public IActionResult Index( string sortBy, string FilterName )
        {
            IEnumerable<Tasks> tasks = _uow.TaskRepository.GetIncluded();
            switch (sortBy)
            {
                case "NameUp": tasks = tasks.OrderBy(t => t.TaskName); ViewBag.Sorting = "NameDown"; break;
                case "DescUp": tasks = tasks.OrderBy(t => t.Desc); ViewBag.Sorting = "DescDown"; break;
                case "StatusUp": tasks = tasks.OrderBy(t => t.Status.StatusName); ViewBag.Sorting = "StatusDown"; break;
                case "PriorityUp": tasks = tasks.OrderBy(t => t.Priority.PriorityName); ViewBag.Sorting = "PriorityDown"; break;
                case "DateUp": tasks = tasks.OrderBy(t => t.CreateDate); ViewBag.Sorting = "DateDown"; break;

                case "NameDown": tasks = tasks.OrderByDescending(t => t.TaskName); ViewBag.Sorting = "NameUp"; break;
                case "DescDown": tasks = tasks.OrderByDescending(t => t.Desc); ViewBag.Sorting = "DescUp"; break;
                case "StatusDown": tasks = tasks.OrderByDescending(t => t.Status.StatusName); ViewBag.Sorting = "StatusUp"; break;
                case "PriorityDown": tasks = tasks.OrderByDescending(t => t.Priority.PriorityName); ViewBag.Sorting = "PriorityUp"; break;
                case "DateDown": tasks = tasks.OrderByDescending(t => t.CreateDate); ViewBag.Sorting = "DateUp"; break;
            }

            if (FilterName != null)
            {
                tasks = tasks.Where(t => t.TaskName==FilterName);
            }
            List<Tasks> model = new List<Tasks>();
            model = tasks.ToList();
            for(int i = 0; i < model.Count; i++)
            {
                model[i].Priority = _uow.PrioritetRepository.GetById(model[i].PriorityGuid);
            }
            return View(tasks);
        }


        public IActionResult Create()
        {
            List<Status> Statuses = _uow.StatusRepository.Get().ToList();
            ViewBag.StatusNew = Statuses.FirstOrDefault(s => s.StatusName == "Новая").Id;
            List<Priority> Prioritets = _uow.PrioritetRepository.Get().ToList();
            ViewBag.Prioritetes = new SelectList(Prioritets, "Id", "PriorityName");

            return View();
        }

        [HttpPost]
        public IActionResult Create( [Bind("Id", "TaskName", "Desc", "PriorityGuid", "StatusId", "CreateDate")] Tasks task )
        {
            _uow.TaskRepository.Insert(task);
            _uow.TaskRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details( Guid id )
        {
            return View(_uow.TaskRepository.GetByIdIncluded(id));
        }


        public IActionResult ChangeStatus( Guid id )
        {
            _uow.TaskRepository.ChangeStatus(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete( Guid id )
        {
            return View(_uow.TaskRepository.GetByIdIncluded(id));
        }

        [HttpPost]
        public IActionResult DeleteConfirmed( Guid id )
        {
            Tasks myTask = _uow.TaskRepository.GetByIdIncluded(id);

            if (myTask == null)
            {
                return NotFound();
            }
            _uow.TaskRepository.Delete(myTask);
            _uow.TaskRepository.Save();
            return RedirectToAction("Index");
        }
    }
}