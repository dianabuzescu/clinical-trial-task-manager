using System.Collections.Generic;
using Clinical_Trial_Task_Manager.Domain.Entities;

namespace Clinical_Trial_Task_Manager.ViewModels
{
    public class TaskItemsIndexViewModel
    {
        public List<TaskItem> Items { get; set; } = new();

        // Filters
        public string? Search { get; set; }  // Title or Patient.Code
        public int? Status { get; set; }     // enum as int
        public int? Priority { get; set; }   // enum as int

        // Sorting
        public string? Sort { get; set; }    // "due_asc" / "due_desc"
    }
}
