using System;
using System.Linq;
using System.Threading.Tasks;
using Clinical_Trial_Task_Manager.Data;
using Clinical_Trial_Task_Manager.Domain.Enums;
using Clinical_Trial_Task_Manager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinical_Trial_Task_Manager.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var today = DateTime.Today;
            var next7 = today.AddDays(7);

            var tasksQuery = _context.TaskItems
                .Include(t => t.Patient);

            var overdueTasks = await tasksQuery
                .Where(t => t.DueDate.Date < today && t.Status != Clinical_Trial_Task_Manager.Domain.Enums.TaskStatus.Done)
                .OrderBy(t => t.DueDate)
                .ToListAsync();

            var next7DaysTasks = await tasksQuery
                .Where(t => t.DueDate.Date >= today && t.DueDate.Date <= next7)
                .OrderBy(t => t.DueDate)
                .ToListAsync();

            var tasksByStatus = await _context.TaskItems
                .GroupBy(t => t.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToListAsync();

            var tasksByPriority = await _context.TaskItems
                .GroupBy(t => t.Priority)
                .Select(g => new { Priority = g.Key, Count = g.Count() })
                .ToListAsync();

            var vm = new DashboardViewModel
            {
                TotalStudies = await _context.Studies.CountAsync(),
                TotalPatients = await _context.Patients.CountAsync(),
                TotalTasks = await _context.TaskItems.CountAsync(),

                OverdueTasksCount = overdueTasks.Count,
                Next7DaysTasksCount = next7DaysTasks.Count,

                OverdueTasks = overdueTasks,
                Next7DaysTasks = next7DaysTasks,

                TasksByStatus = tasksByStatus.ToDictionary(x => x.Status, x => x.Count),
                TasksByPriority = tasksByPriority.ToDictionary(x => x.Priority, x => x.Count)
            };

            return View(vm);
        }
    }
}
