using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.DBClass;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search)
        {
            var tasks = _context.Tasks.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                tasks = tasks.Where(t =>
                    t.TaskTitle.Contains(search) ||
                    t.TaskStatus.Contains(search));
            }

            return View(await tasks.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(TaskModel task)
        {
            task.CreatedOn = DateTime.SpecifyKind(task.CreatedOn, DateTimeKind.Utc);
            task.LastUpdatedOn = DateTime.SpecifyKind(task.LastUpdatedOn, DateTimeKind.Utc);
            task.TaskDueDate = DateTime.SpecifyKind(task.TaskDueDate, DateTimeKind.Utc);
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskModel task)
        {
            task.LastUpdatedOn = DateTime.UtcNow;
            task.CreatedOn = DateTime.SpecifyKind(task.CreatedOn, DateTimeKind.Utc);
            task.TaskDueDate = DateTime.SpecifyKind(task.TaskDueDate, DateTimeKind.Utc);
            _context.Update(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _context.Tasks.FindAsync(id));
        }

        //public async Task<IActionResult> Deletew(int id)
        //{
        //    //return View(await _context.Tasks.FindAsync(id)); 
        //    return View("Index", await _context.Tasks.FindAsync(id));
        //}

        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
