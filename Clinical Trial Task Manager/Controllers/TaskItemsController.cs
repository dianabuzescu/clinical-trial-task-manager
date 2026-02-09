using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinical_Trial_Task_Manager.Data;
using Clinical_Trial_Task_Manager.Domain.Entities;
using Clinical_Trial_Task_Manager.ViewModels;

namespace Clinical_Trial_Task_Manager.Controllers
{
    public class TaskItemsController : Controller
    {
        private readonly AppDbContext _context;

        public TaskItemsController(AppDbContext context)
        {
            _context = context;
        }

        // Helper: builds dropdown items like "CODE - FullName"
        private SelectList BuildPatientSelectList(int? selectedPatientId = null)
        {
            var patients = _context.Patients
                .Select(p => new
                {
                    p.Id,
                    Display = p.Code + " - " + p.FullName
                })
                .OrderBy(x => x.Display)
                .ToList();

            return new SelectList(patients, "Id", "Display", selectedPatientId);
        }

        // GET: TaskItems (with filters + sorting)
        public async Task<IActionResult> Index(string? search, int? status, int? priority, string? sort)
        {
            var query = _context.TaskItems
                .Include(t => t.Patient)
                .AsQueryable();

            // Search: Title OR Patient.Code
            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search.Trim();
                query = query.Where(t =>
                    t.Title.Contains(s) ||
                    (t.Patient != null && t.Patient.Code.Contains(s))
                );
            }

            // Filter: Status
            if (status.HasValue)
            {
                query = query.Where(t => (int)t.Status == status.Value);
            }

            // Filter: Priority
            if (priority.HasValue)
            {
                query = query.Where(t => (int)t.Priority == priority.Value);
            }

            // Sorting
            sort = string.IsNullOrWhiteSpace(sort) ? "due_asc" : sort;
            query = sort == "due_desc"
                ? query.OrderByDescending(t => t.DueDate)
                : query.OrderBy(t => t.DueDate);

            var vm = new TaskItemsIndexViewModel
            {
                Items = await query.ToListAsync(),
                Search = search,
                Status = status,
                Priority = priority,
                Sort = sort
            };

            return View(vm);
        }

        // GET: TaskItems/Details/5
        public async Task<IActionResult> Details(int? id, string? returnUrl = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItems
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (taskItem == null)
            {
                return NotFound();
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(taskItem);
        }

        // GET: TaskItems/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = BuildPatientSelectList();
            return View();
        }

        // POST: TaskItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DueDate,Priority,Status,PatientId")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PatientId"] = BuildPatientSelectList(taskItem.PatientId);
            return View(taskItem);
        }

        // GET: TaskItems/Edit/5
        public async Task<IActionResult> Edit(int? id, string? returnUrl = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItems
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (taskItem == null)
            {
                return NotFound();
            }

            ViewData["PatientId"] = BuildPatientSelectList(taskItem.PatientId);
            ViewData["ReturnUrl"] = returnUrl;

            return View(taskItem);
        }

        // POST: TaskItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Title,DueDate,Priority,Status,PatientId")] TaskItem taskItem,
            string? returnUrl = null)
        {
            if (id != taskItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskItem);
                    await _context.SaveChangesAsync();

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskItemExists(taskItem.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }

            ViewData["PatientId"] = BuildPatientSelectList(taskItem.PatientId);
            ViewData["ReturnUrl"] = returnUrl;
            return View(taskItem);
        }

        // GET: TaskItems/Delete/5
        public async Task<IActionResult> Delete(int? id, string? returnUrl = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItems
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (taskItem == null)
            {
                return NotFound();
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(taskItem);
        }

        // POST: TaskItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string? returnUrl = null)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem != null)
            {
                _context.TaskItems.Remove(taskItem);
                await _context.SaveChangesAsync();
            }

            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction(nameof(Index));
        }

        private bool TaskItemExists(int id)
        {
            return _context.TaskItems.Any(e => e.Id == id);
        }
    }
}
